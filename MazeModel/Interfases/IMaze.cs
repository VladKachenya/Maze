using System.Collections;
using System.Collections.Generic;
using MazeModel.ComplexModels;
using MazeModel.Interfases.ComplexModels;

namespace MazeModel.Interfases
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