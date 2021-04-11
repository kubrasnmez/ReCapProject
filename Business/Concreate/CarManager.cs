using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Apects.Autofac.Caching;
using Core.Apects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //Claim
        [SecuredOperation("car.add,admin")]
        //[ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //business codes 

            IResult result = BusinessRules.Run(CheckIfCarNameExists(car.Description));
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
           
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            
            //İş Kodları
            if(DateTime.Now.Hour ==20)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice > min));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(p=>p.CarId == id));
            
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            List<CarDetailDto> carDetails = _carDal.GetCarDetails();
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(b => b.BrandId == brandId));

        }
         
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId)
        {
           return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId && p.ColorId == colorId));
            
        }
        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(p => p.Description == carName).Any();
            if (result)//==true
            {
                return new ErrorResult("Başka isim girin");
            }

            return new SuccessResult();
        }


        //deneme
        public IDataResult<List<Car>> GetCarsByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }
        
        public IDataResult<List<Car>> GetCarsByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == carId));
        }
    }
}
