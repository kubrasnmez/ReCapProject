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
        /*
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
                                 ColorId = car.ColorId,
                                 ImagePath = (context.CarImages.Where(image => image.CarId == car.CarId).FirstOrDefault().ImagePath,
                                 //CarImageDate = (from carImage in context.CarImages where carImage.CarId == car.CarId select carImage.Date).FirstOrDefault()
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
                
                var result = from c in  context.Cars 
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 ImagePath = context.CarImages.Where(x => x.CarId == c.CarId).FirstOrDefault().ImagePath
                             };
                return result.ToList();
    
            }
        }
                */
        
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
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
                                 CarId = p.CarId,
                                 ImagePath = context.CarImages.Where(x=>x.CarId == p.CarId).FirstOrDefault().ImagePath,
                                 Status = !context.Rentals.Any(r=>r.CarId == p.CarId &&(r.ReturnDate == null || r.RentDate > DateTime.Now))
                                 
                             };
                return result.ToList();
            }
        }
        public CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join r in context.Colors on c.ColorId equals r.ColorId
                             let i = context.CarImages.Where(x => x.CarId == c.CarId).FirstOrDefault()
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = r.ColorName,
                                 Description = c.Description,
                                 
                             };
                return result.SingleOrDefault(filter);
            }
        }
    }
}
