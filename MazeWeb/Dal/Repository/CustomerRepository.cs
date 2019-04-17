using System.Collections.Generic;
using System.Linq;
using Dal.EfStuff;
using Dal.Helper;
using Dal.Interfases.Repository;
using Dal.Model;

namespace Dal.Repository
{
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