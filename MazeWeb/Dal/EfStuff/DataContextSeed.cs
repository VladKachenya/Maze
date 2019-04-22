using MazeWebCore.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

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

        private static IEnumerable<Customer> GetCustomers()
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