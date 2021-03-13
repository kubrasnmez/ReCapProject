
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDbContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from customer in context.Customers
                             join u in context.Users
                             on customer.CustomerId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = customer.CompanyName,
                                 Email = u.Email

                             };
                return result.ToList();
            }
        }
    }
}
