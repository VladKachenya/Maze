using System.Collections.Generic;
using MazeModel.Interfases;

namespace MazeLogic.Interfases.Builders
{
    public interface IMazeBuilder
    {
        List<IBuilder> Builders { get; }
        IMaze ConstrainMaze(int y,int x);
    }
}