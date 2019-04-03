using System.Collections;
using System.Collections.Generic;
using MazeModel.ComplexModels;

namespace MazeModel.Interfases
{
    public interface IMaze : ICoinContainer
    {
        int Width { get; }
        int Height { get; }

        Room this[int y, int x]
        {
            get; set;
        }

        (int, int) GetIndex(Room room);

        IEnumerable<Room> GetEnumerable();

    }   
}