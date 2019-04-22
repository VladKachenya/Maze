using System.Collections.Generic;
using MazeWebCore.Entities;
using MazeWebCore.Helpers.Attributes;

namespace MazeWebCore.Interfaces.Repositories
{
    [ForRegistration]
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> GetByCustomerId(long customerId);
    }
}