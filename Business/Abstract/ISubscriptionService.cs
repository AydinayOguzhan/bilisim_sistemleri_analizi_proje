using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISubscriptionService
    {
        IDataResult<Subscription> GetById(int subscriptionId);
        IDataResult<List<Subscription>> GetList();
        IResult Add(Subscription subscription);
        IResult Delete(Subscription subscription);
        IResult Update(Subscription subscription);
    }
}
