using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFoodService
    {
        IDataResult<Food> GetById(int foodId);
        IDataResult<List<Food>> GetList();
        IResult Add(Food food);
        IResult Delete(Food food);
        IResult Update(Food food);
    }
}
