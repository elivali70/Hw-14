using App.Domain.Core.Entities;
using App.Infrastructure.Database.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Database.SqlServer.Contract.Repositories
{
    public class NorthwindRepository:INorthwindRepository
    {
        private readonly NorthwindContext _northwindContext;

        public NorthwindRepository(NorthwindContext northwindContext)
        {
           _northwindContext = northwindContext;
        }

        public List<Customer> GetCustomers(string family)
        {
          return _northwindContext.Customers.Where(x=>x.ContactName.EndsWith(family)).ToList();
        }

        public List<Customer> GetCustomersByCategoryId(int categoryId)
        {
            return _northwindContext.Customers.Where(x => x.Orders.Any(x => x.OrderDetails.Any(x => x.Product.CategoryId == categoryId))).ToList();
        }

        public List<Order> GetCustomersByRegionId(string region)
        {
            return _northwindContext.Orders.Where(x => x.Employee.Region == region).ToList();
        }

        public List<Employee> GetEmployees(int year)
        {
          return  _northwindContext.Employees.Where(x=>x.HireDate.Value.Year == year).ToList();
        }
    }
}
