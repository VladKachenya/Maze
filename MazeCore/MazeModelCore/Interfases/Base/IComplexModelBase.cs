using MazeModelCore.Helper;

namespace MazeModelCore.Interfases.Base
{
    public interface IComplexModelBase : IModelBase, IEntityContaining
    {
        IModelBase this[Direction direction] { get; }
       
    }
}