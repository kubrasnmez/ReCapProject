using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carImageId);
        IResult Add(CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
    }
}
