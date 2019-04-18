using System.Collections.Generic;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;

namespace MazeModelCore.Interfases.ComplexModels
{
    public interface IRoom : IComplexModelBase
    {
        void SetNeighbor(IModelBase modelBase, Direction key);
        bool IsSealed { get; }
        IEnumerable<KeyValuePair<Direction, IModelBase>> GetEnumerable();
    }
}