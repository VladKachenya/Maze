namespace MazeLogic.Interfases.Converters
{
    public interface IConverter<in U, out V>
    {
        V Convert(U maze);
    }
}