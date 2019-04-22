using Dal.EfStuff;
using MazeWebCore.Entities;
using MazeWebCore.Helpers;
using MazeWebCore.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using MazeWebCore.Helpers.Attributes;

namespace Dal.Repository
{
    [ForRegistration]
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext guessContext) : base(guessContext)
        {
        }

        public IEnumerable<Customer> GetSortedCustomers(CustomerSortEnum sortOrder)
        {
            IEnumerable<Customer> customers;
            switch (sortOrder)
            {
                case CustomerSortEnum.NameAsc: customers = this.GetAll().OrderBy(el => el.Name); break;
                case CustomerSortEnum.NameDesc: customers = this.GetAll().OrderByDescending(el => el.Name); break;
                case CustomerSortEnum.ScoreAsc: customers = this.GetAll().OrderBy(el => el.Score); break;
                case CustomerSortEnum.ScoreDesc: customers = this.GetAll().OrderByDescending(el => el.Score); break;
                case CustomerSortEnum.IdDesc: customers = this.GetAll().OrderByDescending(el => el.Id); break;
                default: customers = this.GetAll().OrderBy(el => el.Id); break;
            }

            return customers;
        }
    }
}