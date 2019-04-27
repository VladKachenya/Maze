using Dal.EfStuff;
using MazeLogicCore.Interfases.Builders;
using MazeModelCore.Interfases.Models;
using MazeWebCore.Entities;
using MazeWebCore.Helpers;
using MazeWebCore.Helpers.Attributes;
using MazeWebCore.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Repository
{
    [ForRegistration]
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {


        [Injection]
        public CustomerRepository(DataContext guessContext) : base(guessContext)
        {
        }

        #region test dependensies injection
        [Injection]
        public IHero MazeProm
        {
            get => null;
            set
            {
                var el = value;
            }
        }

        [Injection]
        public IGameRepository gr
        {
            get => null;
            set
            {
                var el = value;
            }
        }


        [Injection]
        public void SetValue(IHero hero, IMazeBuilder builder, IGameRepository gameRepository)
        {
        }

        [Injection]
        public void SetMethod()
        {
        }
        #endregion


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