using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserMoveService
    {
        IDataResult<UserMove> GetById(int userMoveId);
        IDataResult<List<UserMove>> GetList();
        IResult Add(UserMove userMove);
        IResult Delete(UserMove userMove);
        IResult Update(UserMove userMove);
    }
}
