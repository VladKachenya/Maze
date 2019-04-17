using System.Collections.Generic;
using MazeLogic.Interfases.Engines;
using MazeModel.Helper;
using MazeModel.Interfases;
using MazeModel.Interfases.ComplexModels;
using MazeModel.Models;

namespace MazeLogic.Engines
{
    public class Processor : IEngine
    {
        private Hero _hero;
        private IMaze _maze;
        public List<IEngine> ConfigurationList { get; }

        public Processor(Hero hero, IMaze maze)
        {
            _hero = hero;
            _maze = maze;
            ConfigurationList = new List<IEngine>();
            ConfigurationList.Add(new MoveEngine(hero, maze));
            ConfigurationList.Add(new CollectionEngine(hero, maze));
            ConfigurationList.Add(new ExitSetEngine(maze));
            ConfigurationList.Add(new VictoryEngine(hero, maze));
        }
        public void Move(Direction direction)
        {
            ConfigurationList.ForEach(el => el.Move(direction));
        }
    }
}