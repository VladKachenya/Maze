using System.Collections.Generic;
using MazeLogic.Interfases.Builders;
using MazeModel.ComplexModels;
using MazeModel.Interfases;

namespace MazeLogic.Builders
{
    public class MazeBuilder : IMazeBuilder
    {

        public MazeBuilder()
        {
            Builders = new List<IBuilder>();
            Builders.Add(new RoomBuilder());
            Builders.Add(new WallBuilder());
            Builders.Add(new HeroBuilder());
            Builders.Add(new CorridorBuilder());
        }

        public List<IBuilder> Builders { get; }

        public IMaze ConstrainMaze(int y,int x)
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