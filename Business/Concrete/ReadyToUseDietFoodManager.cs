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
    public class ReadyToUseDietFoodManager : IReadyToUseDietFoodService
    {
        private IReadyToUseDietFoodDal _readyToUseDietFoodDal;

        public ReadyToUseDietFoodManager(IReadyToUseDietFoodDal readyToUseDietFoodDal)
        {
            _readyToUseDietFoodDal = readyToUseDietFoodDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(ReadyToUseDietFoodValidator))]
        [CacheRemoveAspect("IReadyToUseDietFoodService.Get")]
        public IResult Add(ReadyToUseDietFood readyToUseDietFood)
        {
            _readyToUseDietFoodDal.Add(readyToUseDietFood);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(ReadyToUseDietFoodValidator))]
        [CacheRemoveAspect("IReadyToUseDietFoodService.Get")]
        public IResult Delete(ReadyToUseDietFood readyToUseDietFood)
        {
            _readyToUseDietFoodDal.Delete(readyToUseDietFood);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<ReadyToUseDietFood> GetById(int readyToUseDietFoodId)
        {
            var result = _readyToUseDietFoodDal.Get(i=>i.Id == readyToUseDietFoodId);
            return new SuccessDataResult<ReadyToUseDietFood>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<ReadyToUseDietFood>> GetList()
        {
            var result = _readyToUseDietFoodDal.GetList();
            return new SuccessDataResult<List<ReadyToUseDietFood>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(ReadyToUseDietFoodValidator))]
        [CacheRemoveAspect("IReadyToUseDietFoodService.Get")]
        public IResult Update(ReadyToUseDietFood readyToUseDietFood)
        {
            _readyToUseDietFoodDal.Update(readyToUseDietFood);
            return new SuccessResult(Messages.Successful);
        }
    }
}
