using System;
using System.Collections.Generic;
using Dal.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace Dal.EfStuff
{
    public class DataContextSeed
    {
        public static void Seed(DataContext dataContext)
        {
            if (!dataContext.Customers.Any())
            {
                dataContext.Customers.AddRange(GetCustomers());
                dataContext.SaveChanges();
            }
        }

        static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer(){Name = "Artyr", Score = 100},
                new Customer(){Name = "Bil", Score = 0},
                new Customer(){Name = "Vlad", Score = 14},
                new Customer(){Name = "Vika", Score = 0}
            };
        }
       
    }

}