using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ReadyToUseDietFood: IEntity
    {
        public int Id { get; set; }
        public int ReadyToUseDietId { get; set; }
        public int FoodId { get; set; }
    }
}
