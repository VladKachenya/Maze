using MazeModel.Helper;

namespace MazeModel.Interfases.Base
{
    public interface IComplexModelBase : IModelBase, IEntityContaining
    {
        IModelBase this[Direction direction] { get; }
       
    }
}