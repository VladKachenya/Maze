using System.Linq;
using MazeLogic.Interfases.Engines;
using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases;
using MazeModel.Interfases.Base;
using MazeModel.Interfases.ComplexModels;
using MazeModel.Interfases.Models;
using MazeModel.Models;

namespace MazeLogic.Engines
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