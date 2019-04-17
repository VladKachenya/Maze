using System.Collections.Generic;
using Dal.Model.Base;

namespace Dal.Interfases.Repository
{
    public interface IRepository<T> where T: BaseModel
    {
        T Add(T model);
        void AddRange(IEnumerable<T> models);
        IEnumerable<T> GetAll();

        T Get(long id);

        void Remove(long id);

        void Remove(T model);
    }
}