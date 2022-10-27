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
    public class WorkoutPlanManager : IWorkoutPlanService
    {
        private IWorkoutPlanDal _workoutPlanDal;

        public WorkoutPlanManager(IWorkoutPlanDal workoutPlanDal)
        {
            _workoutPlanDal = workoutPlanDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(WorkoutPlanValidator))]
        [CacheRemoveAspect("IWorkoutPlanService.Get")]
        public IResult Add(WorkoutPlan workoutPlan)
        {
            _workoutPlanDal.Add(workoutPlan);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(WorkoutPlanValidator))]
        [CacheRemoveAspect("IWorkoutPlanService.Get")]
        public IResult Delete(WorkoutPlan workoutPlan)
        {
            _workoutPlanDal.Delete(workoutPlan);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<WorkoutPlan> GetById(int workoutPlanId)
        {
            var result = _workoutPlanDal.Get(i=>i.Id == workoutPlanId);
            return new SuccessDataResult<WorkoutPlan>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<WorkoutPlan>> GetList()
        {
            var result = _workoutPlanDal.GetList();
            return new SuccessDataResult<List<WorkoutPlan>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(WorkoutPlanValidator))]
        [CacheRemoveAspect("IWorkoutPlanService.Get")]
        public IResult Update(WorkoutPlan workoutPlan)
        {
            _workoutPlanDal.Update(workoutPlan);
            return new SuccessResult(Messages.Successful);
        }
    }
}
