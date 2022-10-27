using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class WorkoutPlanMove: IEntity
    {
        public int Id { get; set; }
        public int WorkoutPlanId { get; set; }
        public int MoveId { get; set; }
        public int DayId { get; set; }
    }
}
