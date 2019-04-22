using Dal.EfStuff;
using MazeWebCore.Entities.Base;
using MazeWebCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MazeWebCore.Helpers.Attributes;

namespace Dal.Repository
{
    [ForRegistration]
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