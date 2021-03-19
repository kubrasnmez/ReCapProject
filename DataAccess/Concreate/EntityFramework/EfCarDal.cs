using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    //NuGet
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 Description = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                  BrandId = car.BrandId,
                                  ColorId = car.ColorId
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
        /*
        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             select new CarDetailDto
                             {
                                 
                                 BrandName = d.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 ModelYear = p.ModelYear,
                                 CarId = p.CarId
                             };
                return result.ToList();
            }
        }
        */
    }
}
