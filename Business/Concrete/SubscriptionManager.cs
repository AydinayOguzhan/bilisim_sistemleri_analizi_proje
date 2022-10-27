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
    public class SubscriptionManager : ISubscriptionService
    {
        private ISubscriptionDal _subscriptionDal;

        public SubscriptionManager(ISubscriptionDal subscriptionDal)
        {
            _subscriptionDal = subscriptionDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(SubscriptionValidator))]
        [CacheRemoveAspect("ISubscriptionService.Get")]
        public IResult Add(Subscription subscription)
        {
            _subscriptionDal.Add(subscription);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(SubscriptionValidator))]
        [CacheRemoveAspect("ISubscriptionService.Get")]
        public IResult Delete(Subscription subscription)
        {
            _subscriptionDal.Delete(subscription);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<Subscription> GetById(int subscriptionId)
        {
            var result = _subscriptionDal.Get(i=>i.Id == subscriptionId);
            return new SuccessDataResult<Subscription>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<Subscription>> GetList()
        {
            var result = _subscriptionDal.GetList();
            return new SuccessDataResult<List<Subscription>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(SubscriptionValidator))]
        [CacheRemoveAspect("ISubscriptionService.Get")]
        public IResult Update(Subscription subscription)
        {
            _subscriptionDal.Update(subscription);
            return new SuccessResult(Messages.Successful);
        }
    }
}
