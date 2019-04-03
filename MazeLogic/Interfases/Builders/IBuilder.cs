using System.Collections.Generic;
using MazeModel.Interfases;

namespace MazeLogic.Interfases.Builders
{
    public interface IBuilder
    {
        void Build(ref IMaze maze);
    }
}