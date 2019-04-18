using MazeLogicCore.Interfases.Builders;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;

namespace MazeLogicCore.Builders
{
    public class HeroBuilder : IBuilder
    {
        private readonly IHero _hero;

        public HeroBuilder(IHero hero)
        {
            _hero = hero;
        }

        public void Build(IMaze maze)
        {
            maze[0, 0].Content = _hero;
        }
    }
}