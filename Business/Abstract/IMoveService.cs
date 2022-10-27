using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMoveService
    {
        IDataResult<Move> GetById(int moveId);
        IDataResult<List<Move>> GetList();
        IResult Add(Move move);
        IResult Delete(Move move);
        IResult Update(Move move);
    }
}
