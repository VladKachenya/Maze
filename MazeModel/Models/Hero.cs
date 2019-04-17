using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases;
using MazeModel.Interfases.Models;

namespace MazeModel.Models
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