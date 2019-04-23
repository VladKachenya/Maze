using System.Collections.Generic;
using MazeWebCore.Helpers.Attributes;

namespace MazeWebCore.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T Add(T model);
        void AddRange(IEnumerable<T> models);
        IEnumerable<T> GetAll();

        T Get(long id);

        void Remove(long id);

        void Remove(T model);
    }
}