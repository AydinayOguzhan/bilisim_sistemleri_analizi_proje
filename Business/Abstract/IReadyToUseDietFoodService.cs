using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReadyToUseDietFoodService
    {
        IDataResult<ReadyToUseDietFood> GetById(int readyToUseDietFoodId);
        IDataResult<List<ReadyToUseDietFood>> GetList();
        IResult Add(ReadyToUseDietFood readyToUseDietFood);
        IResult Delete(ReadyToUseDietFood readyToUseDietFood);
        IResult Update(ReadyToUseDietFood readyToUseDietFood);
    }
}
