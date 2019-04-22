using System.Collections.Generic;
using MazeWebCore.Entities;
using MazeWebCore.Helpers;
using MazeWebCore.Helpers.Attributes;

namespace MazeWebCore.Interfaces.Repositories
{
    [ForRegistration]
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetSortedCustomers(CustomerSortEnum sortOrder);
    }
}