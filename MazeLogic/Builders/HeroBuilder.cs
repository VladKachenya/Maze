using MazeLogic.Interfases.Builders;
using MazeModel.Interfases;
using MazeModel.Models;

namespace MazeLogic.Builders
{
    public class HeroBuilder : IBuilder
    {
        public void Build(ref IMaze maze)
        {
            var hero = Hero.GetHero;
            hero.IsWin = false;
            maze[0, 0].Content = hero;
        }
    }
}