using Core.Entities.Concreate;
using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult UpdateInfos(User user);

        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);

    }
}
