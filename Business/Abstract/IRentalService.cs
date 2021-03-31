using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetail();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId);
        IDataResult<List<Rental>> GetByCustomerId(int id);
    }
}