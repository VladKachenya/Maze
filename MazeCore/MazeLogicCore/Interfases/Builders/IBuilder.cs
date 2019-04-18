using MazeModelCore.Interfases.ComplexModels;

namespace MazeLogicCore.Interfases.Builders
{
    public interface IBuilder
    {
        void Build(IMaze maze);
    }
}