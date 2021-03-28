using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Dal - Data Access Layer
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        //List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null);
    }
}
// Code Refactoring