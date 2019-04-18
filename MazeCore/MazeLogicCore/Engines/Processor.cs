using System.Collections.Generic;
using MazeLogicCore.Interfases.Engines;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;
using MazeModelCore.Models;

namespace MazeLogicCore.Engines
{
    public class Processor : IEngine
    {
        private IHero _hero;
        private IMaze _maze;
        public List<IEngine> ConfigurationList { get; }

        public Processor(IHero hero, IMaze maze)
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