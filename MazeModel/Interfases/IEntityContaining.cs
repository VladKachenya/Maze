using MazeModel.Base;

namespace MazeModel.Interfases
{
    public interface IEntityContaining
    {
        ModelBase Content { get; set; }
        bool IsEmpty { get; }
    }
}