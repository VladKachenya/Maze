using System.Collections.Generic;
using MazeLogicCore.Interfases.Builders;
using MazeModelCore.ComplexModels;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;
using MazeModelCore.Models;

namespace MazeLogicCore.Builders
{
    public class MazeBuilder : IMazeBuilder
    {

        public MazeBuilder(IHero hero)
        {
            Builders = new List<IBuilder>();
            Builders.Add(new RoomBuilder());
            Builders.Add(new WallBuilder());
            Builders.Add(new HeroBuilder(hero));
            Builders.Add(new CorridorBuilder((dir, m1, m2) => new Сorridor(dir, m1, m2)));
            Builders.Add(new CoinBuilder(10, () => new Coin()));
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