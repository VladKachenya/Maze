using MazeLogic.Interfases.Builders;
using MazeModel.ComplexModels;
using MazeModel.Interfases.ComplexModels;
using MazeModel.Interfases.Models;
using MazeModel.Models;
using System;
using System.Collections.Generic;

namespace MazeLogic.Builders
{
    public class MazeBuilder : IMazeBuilder
    {

        public MazeBuilder()
        {
            Builders = new List<IBuilder>();
            Builders.Add(new RoomBuilder());
            Builders.Add(new WallBuilder());
            Builders.Add(new HeroBuilder(() => Hero.GetHero));
            Builders.Add(new CorridorBuilder((dir, m1, m2) => new Сorridor(dir, m1, m2)));
        }

        public List<IBuilder> Builders { get; }

        public IMaze ConstrainMaze(int y, int x)
        {
            IMaze res = new Maze(y, x);
            foreach (var builder in Builders)
            {
                builder.Build(res);
            }
            return res;
        }
    }
}