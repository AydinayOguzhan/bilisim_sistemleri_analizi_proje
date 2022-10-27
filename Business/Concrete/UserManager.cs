using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<UserSubscriptionDetailsDto> GetByMail(string email)
        {
            var result = _userDal.GetUserByMail(email);
            return new SuccessDataResult<UserSubscriptionDetailsDto>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(i=>i.Id == userId);
            return new SuccessDataResult<User>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Successful);
        }
    }
}
