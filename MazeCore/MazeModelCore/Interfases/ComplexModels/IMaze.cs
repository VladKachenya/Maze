using System.Collections.Generic;

namespace MazeModelCore.Interfases.ComplexModels
{
    public interface IMaze : ICoinContainer
    {
        int Width { get; }
        int Height { get; }

        IRoom this[int y, int x]
        {
            get; set;
        }

        (int, int) GetIndex(IRoom room);

        IEnumerable<IRoom> GetEnumerable();

    }   
}