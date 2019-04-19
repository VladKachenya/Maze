using System.Collections.Generic;
using Dal.Helper.CustomAttribute;
using Dal.Model.Base;

namespace Dal.Model
{
    public class Customer : BaseModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Game> Games { get; set; }
    }
}