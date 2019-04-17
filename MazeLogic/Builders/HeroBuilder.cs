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