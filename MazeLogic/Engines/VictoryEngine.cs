using System;
using System.Linq;
using MazeLogic.Interfases.Engines;
using MazeModel.Base;
using MazeModel.ComplexModels;
using MazeModel.Helper;
using MazeModel.Interfases;
using MazeModel.Interfases.ComplexModels;
using MazeModel.Models;

namespace MazeLogic.Engines
{
    public class VictoryEngine : IEngine
    {
        private readonly Hero _hero;
        private readonly IMaze _maze;
        private Exit _exit;

        public VictoryEngine(Hero hero, IMaze maze)
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