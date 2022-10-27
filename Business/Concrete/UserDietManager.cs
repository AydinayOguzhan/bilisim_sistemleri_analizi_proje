using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserDietManager : IUserDietService
    {
        private IUserDietDal _userDietDal;

        public UserDietManager(IUserDietDal userDietDal)
        {
            _userDietDal = userDietDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UesrDietValidator))]
        [CacheRemoveAspect("IUserDietService.Get")]
        public IResult Add(UserDiet userDiet)
        {
            _userDietDal.Add(userDiet);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UesrDietValidator))]
        [CacheRemoveAspect("IUserDietService.Get")]
        public IResult Delete(UserDiet userDiet)
        {
            _userDietDal.Delete(userDiet);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<UserDiet> GetById(int userDietId)
        {
            var result = _userDietDal.Get(i=>i.Id == userDietId);
            return new SuccessDataResult<UserDiet>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<UserDiet>> GetList()
        {
            var result = _userDietDal.GetList();
            return new SuccessDataResult<List<UserDiet>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UesrDietValidator))]
        [CacheRemoveAspect("IUserDietService.Get")]
        public IResult Update(UserDiet userDiet)
        {
            _userDietDal.Update(userDiet);
            return new SuccessResult(Messages.Successful);
        }
    }
}
