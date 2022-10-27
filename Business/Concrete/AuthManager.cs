using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private ISubscriptionService _subscriptionService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ISubscriptionService subscriptionService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _subscriptionService = subscriptionService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash,out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PhoneNumber = userForRegisterDto.PhoneNumber
            };
            _userService.Add(user);
            var result = _userService.GetByMail(user.Email);

            var subscription = new Subscription
            {
                UserId = result.Data.Id,
                SubscriptionStart = userForRegisterDto.SubscriptionStart,
                SubscriptionEnd = userForRegisterDto.SubscriptionEnd
            };
            return  new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IDataResult<UserSubscriptionDetailsDto> Login(UserForLoginDto userForLoginDto)
        {
            //Check if user exists
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck==null)
            {
                return new ErrorDataResult<UserSubscriptionDetailsDto>(Messages.UserNotFound);
            }

            var ruleResult = BusinessRules.Run(IfSubscribe(userToCheck.Data.SubscriptionEnd));
            if (ruleResult != null)
            {
                return new ErrorDataResult<UserSubscriptionDetailsDto>(Messages.Unsuccessful);
            }

            //Verify password
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.Data.PasswordHash,
                userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<UserSubscriptionDetailsDto>(Messages.PasswordError);
            }

            return new SuccessDataResult<UserSubscriptionDetailsDto>(userToCheck.Data,Messages.SuccessfulLogin);
        }

        private IResult IfSubscribe(DateTime subscriptionEnd)
        {
            var today = new DateTime();
            if (subscriptionEnd <= today)
            {
                return new ErrorResult(Messages.SubscriptionEnded);
            }
            return new SuccessResult();
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }
    }
}
