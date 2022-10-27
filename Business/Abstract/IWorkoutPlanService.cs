using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkoutPlanService
    {
        IDataResult<WorkoutPlan> GetById(int workoutPlanId);
        IDataResult<List<WorkoutPlan>> GetList();
        IResult Add(WorkoutPlan workoutPlan);
        IResult Delete(WorkoutPlan workoutPlan);
        IResult Update(WorkoutPlan workoutPlan);
    }
}
