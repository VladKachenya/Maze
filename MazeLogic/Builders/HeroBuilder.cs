using System;
using MazeLogic.Interfases.Builders;
using MazeModel.Interfases;
using MazeModel.Interfases.Base;
using MazeModel.Interfases.ComplexModels;
using MazeModel.Interfases.Models;
using MazeModel.Models;

namespace MazeLogic.Builders
{
    public class HeroBuilder : IBuilder
    {
        private readonly Func<IHero> _heroFactoryFunc;

        public HeroBuilder(Func<IHero> heroFactoryFunc)
        {
            _heroFactoryFunc = heroFactoryFunc;
        }

        public void Build(IMaze maze)
        {
            var hero = _heroFactoryFunc();//Hero.GetHero;
            hero.IsWin = false;
            maze[0, 0].Content = hero;
        }
    }
}