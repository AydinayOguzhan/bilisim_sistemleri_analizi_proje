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
    public class DayManager : IDayService
    {
        private IDayDal _dayDal;

        public DayManager(IDayDal dayDal)
        {
            _dayDal = dayDal;
        }

        //[SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(DayValidator))]
        [CacheRemoveAspect("IDayService.Get")]
        public IResult Add(Day day)
        {
            _dayDal.Add(day);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(DayValidator))]
        [CacheRemoveAspect("IDayService.Get")]
        public IResult Delete(Day day)
        {
            _dayDal.Delete(day);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<Day> GetById(int dayId)
        {
            var result = _dayDal.Get(i=>i.Id == dayId);
            return new SuccessDataResult<Day>(result);
        }

        [CacheAspect]
        public IDataResult<List<Day>> GetList()
        {
            var result = _dayDal.GetList();
            return new SuccessDataResult<List<Day>>(result,Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(DayValidator))]
        [CacheRemoveAspect("IDayService.Get")]
        public IResult Update(Day day)
        {
            _dayDal.Update(day);
            return new SuccessResult(Messages.Successful);
        }
    }
}
