using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases;

namespace MazeModel.Models
{
    public class Hero : ModelBase, ICollector, ICoinContainer, IWiner
    {
        private static Hero _hero;

        private Hero() : base(Keys.HeroKey)
        {
            CoinCount = 0;
            IsWin = false;
        }
        public static Hero GetHero
        {
            get
            {
                if (_hero == null)
                {
                    _hero = new Hero();
                }
                return _hero;
            }
        }

        public int CoinCount { get; private set; }

        public void Collect()
        {
            CoinCount++;
        }

        public bool IsWin { get; set; }
    }
}