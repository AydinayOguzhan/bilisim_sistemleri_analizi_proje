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
    public class MoveManager : IMoveService
    {
        private IMoveDal _moveDal;

        public MoveManager(IMoveDal moveDal)
        {
            _moveDal = moveDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(MoveValidator))]
        [CacheRemoveAspect("IMoveService.Get")]
        public IResult Add(Move move)
        {
            _moveDal.Add(move);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(MoveValidator))]
        [CacheRemoveAspect("IMoveService.Get")]
        public IResult Delete(Move move)
        {
            _moveDal.Delete(move);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<Move> GetById(int moveId)
        {
            var result = _moveDal.Get(i=>i.Id == moveId);
            return new SuccessDataResult<Move>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<Move>> GetList()
        {
            var result = _moveDal.GetList();
            return new SuccessDataResult<List<Move>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(MoveValidator))]
        [CacheRemoveAspect("IMoveService.Get")]
        public IResult Update(Move move)
        {
            _moveDal.Update(move);
            return new SuccessResult(Messages.Successful);
        }
    }
}
