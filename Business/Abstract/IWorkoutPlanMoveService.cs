using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkoutPlanMoveService
    {
        IDataResult<WorkoutPlanMove> GetById(int workoutPlanMoveId);
        IDataResult<List<WorkoutPlanMove>> GetList();
        IResult Add(WorkoutPlanMove workoutPlanMove);
        IResult Delete(WorkoutPlanMove workoutPlanMove);
        IResult Update(WorkoutPlanMove workoutPlanMove);
    }
}
