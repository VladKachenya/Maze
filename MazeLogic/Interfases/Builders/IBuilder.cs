using System.Collections.Generic;
using MazeModel.Interfases;
using MazeModel.Interfases.ComplexModels;

namespace MazeLogic.Interfases.Builders
{
    public interface IBuilder
    {
        void Build(IMaze maze);
    }
}