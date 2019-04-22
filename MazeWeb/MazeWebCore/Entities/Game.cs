using System;
using MazeWebCore.Entities.Base;

namespace MazeWebCore.Entities
{
    public class Game : BaseModel
    {
        public DateTime Date { get; set; }
        public virtual Customer Gamer { get; set; }

    }
}