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
    public class FoodManager : IFoodService
    {
        private IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(FoodValidator))]
        [CacheRemoveAspect("IFoodService.Get")]
        public IResult Add(Food food)
        {
            _foodDal.Add(food);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(FoodValidator))]
        [CacheRemoveAspect("IFoodService.Get")]
        public IResult Delete(Food food)
        {
            _foodDal.Delete(food);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<Food> GetById(int foodId)
        {
            var result = _foodDal.Get(i=>i.Id == foodId);
            return new SuccessDataResult<Food>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<Food>> GetList()
        {
            var result = _foodDal.GetList();
            return new SuccessDataResult<List<Food>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(FoodValidator))]
        [CacheRemoveAspect("IFoodService.Get")]
        public IResult Update(Food food)
        {
            _foodDal.Update(food);
            return new SuccessResult(Messages.Successful);
        }
    }
}
