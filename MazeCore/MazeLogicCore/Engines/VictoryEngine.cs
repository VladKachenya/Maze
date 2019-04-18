using System.Linq;
using MazeLogicCore.Interfases.Engines;
using MazeModelCore.ComplexModels;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;
using MazeModelCore.Models;

namespace MazeLogicCore.Engines
{
    public class VictoryEngine : IEngine
    {
        private readonly IHero _hero;
        private readonly IMaze _maze;
        private Exit _exit;

        public VictoryEngine(IHero hero, IMaze maze)
        {
            _hero = hero;
            _maze = maze;
        }
        public void Move(Direction direction)
        {
            
            if(_maze.CoinCount == 0)
            {
                if (_exit == null)
                {
                    foreach (var room in _maze.GetEnumerable())
                    {
                        _exit = room.GetEnumerable().FirstOrDefault(el => el.Value.ElementName == Keys.ExitKey).Value as Exit;
                        if(_exit != null) { break;}
                    }
                }
                _hero.IsWin = _exit?.Content.ElementName == Keys.HeroKey;
            }
        }

       
    }
}