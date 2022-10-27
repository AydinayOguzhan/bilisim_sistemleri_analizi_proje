using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,NorthwindContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
                return result.ToList();

            }
        }

        public UserSubscriptionDetailsDto GetUserByMail(string email)
        {
            using (var context = new NorthwindContext())
            {
                var result = from user in context.Users
                             join subscription in context.Subscriptions
                             on user.Id equals subscription.UserId
                             where user.Email == email
                             select new UserSubscriptionDetailsDto
                             {
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 Id = user.Id,
                                 LastName = user.LastName,
                                 PasswordHash = user.PasswordHash,
                                 PasswordSalt = user.PasswordSalt,
                                 PhoneNumber = user.PhoneNumber,
                                 SubscriptionEnd = subscription.SubscriptionEnd,
                                 SubscriptionStart = subscription.SubscriptionStart
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
