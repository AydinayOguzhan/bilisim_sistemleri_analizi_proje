using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReadyToUseDietService
    {
        IDataResult<ReadyToUseDiet> GetById(int readyToUseDietId);
        IDataResult<List<ReadyToUseDiet>> GetList();
        IResult Add(ReadyToUseDiet readyToUseDiet);
        IResult Delete(ReadyToUseDiet readyToUseDiet);
        IResult Update(ReadyToUseDiet readyToUseDiet);
    }
}
