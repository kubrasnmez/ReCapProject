using Business.Abstract;
using Business.Constants;
using Core.Entities.Concreate;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        public IResult Delete (User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            return new SuccessDataResult<User>(result);
        }
        public IResult UpdateInfos(User user)
        {
            var userToUpdate = GetById(user.Id).Data;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            Update(userToUpdate);
            return new SuccessResult();
        }
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.GetAll().Where(u => u.Email == email).FirstOrDefault());
        }


    }
}
