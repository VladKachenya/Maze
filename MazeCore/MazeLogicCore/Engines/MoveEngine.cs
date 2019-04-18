using System.Linq;
using MazeLogicCore.Interfases.Engines;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;

namespace MazeLogicCore.Engines
{
    public class MoveEngine : IEngine
    {
        private readonly IHero _hero;
        private readonly IMaze _maze;
        private IComplexModelBase _currentCell;

        public MoveEngine(IHero hero, IMaze maze)
        {
            _hero = hero;
            _maze = maze;
            _currentCell = _maze.GetEnumerable().First(el => el.Content.ElementName == Keys.HeroKey);
        }
        public void Move(Direction direction)
        {
            var obj = _currentCell[direction];
            if (obj is IComplexModelBase nextCell)
            {
                nextCell.Content = _hero;
                _currentCell.Content = null;
                _currentCell = nextCell;
            }
        }
    }
}