using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concreate;

namespace DataAccess.Abstract
{
    public interface IColorDal:IEntityRepository<Color>
    {
    }
}
