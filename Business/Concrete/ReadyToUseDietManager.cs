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
    public class ReadyToUseDietManager : IReadyToUseDietService
    {
        private IReadyToUseDietDal _readyTOUseDietDal;

        public ReadyToUseDietManager(IReadyToUseDietDal readyTOUseDietDal)
        {
            _readyTOUseDietDal = readyTOUseDietDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(ReadyToUseDietValidator))]
        [CacheRemoveAspect("IReadyToUseDietService.Get")]
        public IResult Add(ReadyToUseDiet readyToUseDiet)
        {
            _readyTOUseDietDal.Add(readyToUseDiet);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(ReadyToUseDietValidator))]
        [CacheRemoveAspect("IReadyToUseDietService.Get")]
        public IResult Delete(ReadyToUseDiet readyToUseDiet)
        {
            _readyTOUseDietDal.Delete(readyToUseDiet);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<ReadyToUseDiet> GetById(int readyToUseDietId)
        {
            var result = _readyTOUseDietDal.Get(i=>i.Id == readyToUseDietId);
            return new SuccessDataResult<ReadyToUseDiet>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<ReadyToUseDiet>> GetList()
        {
            var result = _readyTOUseDietDal.GetList();
            return new SuccessDataResult<List<ReadyToUseDiet>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(ReadyToUseDietValidator))]
        [CacheRemoveAspect("IReadyToUseDietService.Get")]
        public IResult Update(ReadyToUseDiet readyToUseDiet)
        {
            _readyTOUseDietDal.Update(readyToUseDiet);
            return new SuccessResult(Messages.Successful);
        }
    }
}
