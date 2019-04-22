using System.Collections.Generic;
using MazeWebCore.Entities.Base;

namespace MazeWebCore.Entities
{
    public class Customer : BaseModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Game> Games { get; set; }
    }
}