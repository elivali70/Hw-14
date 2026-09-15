using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.Entities;

namespace App.Infrastructure.Database.SqlServer.Contract.Repositories
{
    public interface INorthwindRepository
    {
       List<Employee> GetEmployees(int year);
        List<Customer> GetCustomers(string family);
        List<Customer> GetCustomersByCategoryId(int categoryId);
        List<Order> GetCustomersByRegionId(string region);
    }
}
