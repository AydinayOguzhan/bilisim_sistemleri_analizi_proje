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
    public class WorkoutPlanMoveManager : IWorkoutPlanMoveService
    {
        private IWorkoutPlanMoveDal _workoutPlanMoveDal;

        public WorkoutPlanMoveManager(IWorkoutPlanMoveDal workoutPlanMoveDal)
        {
            _workoutPlanMoveDal = workoutPlanMoveDal;
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(WorkoutPlanMoveValidator))]
        [CacheRemoveAspect("IWorkoutPlanMoveService.Get")]
        public IResult Add(WorkoutPlanMove workoutPlanMove)
        {
            _workoutPlanMoveDal.Add(workoutPlanMove);
            return new SuccessResult(Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(WorkoutPlanMoveValidator))]
        [CacheRemoveAspect("IWorkoutPlanMoveService.Get")]
        public IResult Delete(WorkoutPlanMove workoutPlanMove)
        {
            _workoutPlanMoveDal.Delete(workoutPlanMove);
            return new SuccessResult(Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<WorkoutPlanMove> GetById(int workoutPlanMoveId)
        {
            var result = _workoutPlanMoveDal.Get(i=>i.Id == workoutPlanMoveId);
            return new SuccessDataResult<WorkoutPlanMove>(result, Messages.Successful);
        }

        [CacheAspect]
        public IDataResult<List<WorkoutPlanMove>> GetList()
        {
            var result = _workoutPlanMoveDal.GetList();
            return new SuccessDataResult<List<WorkoutPlanMove>>(result, Messages.Successful);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(WorkoutPlanMoveValidator))]
        [CacheRemoveAspect("IWorkoutPlanMoveService.Get")]
        public IResult Update(WorkoutPlanMove workoutPlanMove)
        {
            _workoutPlanMoveDal.Update(workoutPlanMove);
            return new SuccessResult(Messages.Successful);
        }
    }
}
