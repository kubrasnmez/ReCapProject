using Business.Concreate;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concreate.InMemory;
using Entities.Concreate;
using System;

namespace ConsoleUI
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Referans tutucular abstract klasörünün içine konulur.
    
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 150,
                ModelYear = 2016,
                Description = "Hyundai 2016"
            });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t" + car.DailyPrice + "\t" + car.ModelYear + "\t" + car.Description);
            }
          
        }
    }
}
