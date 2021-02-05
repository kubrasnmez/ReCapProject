using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Dal - Data Access Layer
    public interface ICarDal:IEntityRepository<Car>
    {

    }
}
