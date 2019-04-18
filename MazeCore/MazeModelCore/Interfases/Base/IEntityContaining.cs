namespace MazeModelCore.Interfases.Base
{
    public interface IEntityContaining
    {
        IModelBase Content { get; set; }
        bool IsEmpty { get; }
    }
}