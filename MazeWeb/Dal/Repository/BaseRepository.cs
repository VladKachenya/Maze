using Dal.EfStuff;
using Dal.Interfases;
using Dal.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Dal.Interfases.Repository;

namespace Dal.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected DataContext DataContext { get; set; }
        protected DbSet<T> Entity { get; set; }

        public BaseRepository(DataContext guessContext)
        {
            DataContext = guessContext;
            Entity = DataContext.Set<T>();
        }

        public T Add(T model)
        {
            Entity.Add(model);
            DataContext.SaveChanges();
            return model;
        }

        public void AddRange(IEnumerable<T> models)
        {
            Entity.AddRange(models);
            DataContext.SaveChanges();
        }


        public IEnumerable<T> GetAll()
        {
            return Entity.ToList();
        }

        public T Get(long id)
        {
            return Entity.SingleOrDefault(x => x.Id == id);
        }

        public void Remove(long id)
        {
            Remove(Get(id));
        }

        public void Remove(T model)
        {
            Entity.Remove(model);
            DataContext.SaveChanges();
        }
    }
}