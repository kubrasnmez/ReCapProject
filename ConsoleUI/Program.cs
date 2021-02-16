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
            //CarAdd();
            //BrandAdd();
            //BrandTest();
            //ColorAdd();
            //CarDetail();
            //UserAdd();
            //CustomerAdd();
            //CustomerDetail();
            RentalAdd();
        }
        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("Car id : ");
            int carid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer id : ");
            int customerid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("rent date");
            DateTime rentdate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("return date");
            DateTime returndate = Convert.ToDateTime(Console.ReadLine());
            Rental rental = new Rental();
            rental = new Rental()
            {
                CarId = carid,
                CustomerId = customerid,
                RentDate = rentdate,
                ReturnDate = returndate
            };
            rentalManager.Add(rental);
        }
        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("Kullanıcı id: ");
            int userid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Şirket Adı : ");
            string companyname = Console.ReadLine();
            Customer customer = new Customer();
            customer = new Customer()
            {
                UserId = userid,
                CompanyName = companyname
            };
            customerManager.Add(customer);
        }
        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.Write("Kullanıcı Adı : ");
            string firstName = Console.ReadLine();
            Console.Write("Kullanıcı Soyadı : ");
            string lastName = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Şifre : ");
            string password = Console.ReadLine();
            User user = new User();
            user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password

            };
            userManager.Add(user);
        }

        private static void CustomerDetail()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetail();
            if(result.Success == true)
            {
                foreach (var customer in customerManager.GetCustomerDetail().Data) 
                {
                    Console.WriteLine(customer.FirstName + "\t" + customer.LastName + "\t" + customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        private static void CarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.Success == true)
            {
                foreach (var car in carManager.GetCarDetail().Data)
                {
                    Console.WriteLine(car.Description + "\t" + car.BrandName + "\t" + car.ColorName + "\t" + car.DailyPrice);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color
            {
                ColorName = "Siyah"
            });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand
            {
                BrandName = "Toyota"
            });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 150,
                ModelYear = 2016,
                Description = "Hyundai 2016"
            });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + "\t" + car.BrandId + "\t" + car.ColorId + "\t" + car.DailyPrice + "\t" + car.ModelYear + "\t" + car.Description);
            }
        }
    }
}
