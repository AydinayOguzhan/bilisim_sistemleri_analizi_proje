using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserDietService
    {
        IDataResult<UserDiet> GetById(int userDietId);
        IDataResult<List<UserDiet>> GetList();
        IResult Add(UserDiet userDiet);
        IResult Delete(UserDiet userDiet);
        IResult Update(UserDiet userDiet);
    }
}
