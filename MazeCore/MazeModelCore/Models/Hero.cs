using MazeModelCore.Base;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Models;

namespace MazeModelCore.Models
{
    public class Hero : ModelBase, IHero
    {

        public Hero() : base(Keys.HeroKey)
        {
            CoinCount = 0;
            IsWin = false;
        }

        public int CoinCount { get; private set; }

        public void Collect()
        {
            CoinCount++;
        }

        public bool IsWin { get; set; }
    }
}