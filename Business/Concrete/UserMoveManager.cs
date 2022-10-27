using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
    public class UserMoveManager : IUserMoveService
    {
        private IUserMoveDal _userMoveDal;

        public UserMoveManager(IUserMoveDal userMoveDal)
        {
            _userMoveDal = userMoveDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UserMoveValidator))]
        [CacheRemoveAspect("IUserMoveService.Get")]
        public IResult Add(UserMove userMove)
        {
            _userMoveDal.Add(userMove);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UserMoveValidator))]
        [CacheRemoveAspect("IUserMoveService.Get")]
        public IResult Delete(UserMove userMove)
        {
            _userMoveDal.Delete(userMove);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<UserMove> GetById(int userMoveId)
        {
            var result = _userMoveDal.Get(i=>i.Id == userMoveId);
            return new SuccessDataResult<UserMove>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<UserMove>> GetList()
        {
            var result = _userMoveDal.GetList();
            return new SuccessDataResult<List<UserMove>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(UserMoveValidator))]
        [CacheRemoveAspect("IUserMoveService.Get")]
        public IResult Update(UserMove userMove)
        {
            _userMoveDal.Update(userMove);
            return new SuccessResult(Messages.Successful);
        }
    }
}
