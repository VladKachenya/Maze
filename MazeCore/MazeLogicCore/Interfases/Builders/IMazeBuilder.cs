using System.Collections.Generic;
using MazeModelCore.Interfases.ComplexModels;

namespace MazeLogicCore.Interfases.Builders
{
    public interface IMazeBuilder
    {
        List<IBuilder> Builders { get; }
        IMaze ConstrainMaze(int y,int x);
    }
}