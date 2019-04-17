using System.Collections.Generic;
using Dal.Helper;
using Dal.Model;

namespace Dal.Interfases.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetSortedCustomers(CustomerSortEnum sortOrder);
    }
}