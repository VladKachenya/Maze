using System.Collections.Generic;
using MazeModel.Helper;
using MazeModel.Interfases.Base;

namespace MazeModel.Interfases.ComplexModels
{
    public interface IRoom : IComplexModelBase
    {
        void SetNeighbor(IModelBase modelBase, Direction key);
        bool IsSealed { get; }
        IEnumerable<KeyValuePair<Direction, IModelBase>> GetEnumerable();
    }
}