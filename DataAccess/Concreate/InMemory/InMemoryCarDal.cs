using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.InMemory
{
    
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        { 
            _cars = new List<Car> { 
                new Car{Id=1, BrandId = 1, ColorId = 1, DailyPrice = 50, ModelYear = 2001, Description = "Otomatik Vites, 5 koltuk" },
                new Car{Id=2, BrandId = 2, ColorId = 2, DailyPrice = 70, ModelYear = 2006, Description = "Otomatik Vites, 5 koltuk" },
                new Car{Id=3, BrandId = 1, ColorId = 3, DailyPrice = 90, ModelYear = 2008, Description = "Otomatik Vites, 5 koltuk" },
                new Car{Id=4, BrandId = 2, ColorId = 2, DailyPrice = 50, ModelYear = 2002, Description = "Manuel Vites, 5 koltuk" },
                new Car{Id=5, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2007, Description = "Otomatik Vites, 5 koltuk" },
            
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //SingleOrDefault - Id bazlılarda kullanılır. Tek değer döndürür.
            //LINQ
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id); //Tek tek dolaşmak
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            //Where koşulu, koşula uyanları yeni bir liste yapıp döndürür.
            return  _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id); //Tek tek dolaşmak
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
