using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDayService
    {
        IDataResult<Day> GetById(int dayId);
        IDataResult<List<Day>> GetList();
        IResult Add(Day day);
        IResult Delete(Day day);
        IResult Update(Day day);
    }
}
