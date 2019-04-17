using System;
using Dal.Model.Base;

namespace Dal.Model
{
    public class Game : BaseModel
    {
        public DateTime Date { get; set; }
        public virtual Customer Gamer { get; set; }

    }
}