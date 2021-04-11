
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDbContext>,ICustomerDal
    {
        public CustomerDetailDto getCustomerByEmail(Expression<Func<CustomerDetailDto, bool>> filter)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                                 on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName,
                                 CustomerFindex = (int)customer.CustomerFindex
                             };
                return result.SingleOrDefault(filter);
            }
        }

        public List<CustomerDetailDto> GetCustomerDetail(Expression<Func<Customer, bool>> filter = null)
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
                                 Email = u.Email,
                                 CustomerFindex = (int)customer.CustomerFindex

                             };
                return result.ToList();
            }
        }
    }
}
