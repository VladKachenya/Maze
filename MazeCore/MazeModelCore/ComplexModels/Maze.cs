using System;
using System.Collections.Generic;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.ComplexModels;

namespace MazeModelCore.ComplexModels
{
    public class Maze : IMaze
    {
        protected IRoom[,] _rooms;

        public Maze(int height, int width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentException();
            }
            Width = width;
            Height = height;
            _rooms = new IRoom[Height, Width];
        }
        public int Width { get; }
        public int Height { get; }

        public IRoom this[int y, int x]
        {
            get => _rooms[y, x] ;
            set => _rooms[y, x] = value;
        }

        public (int, int) GetIndex(IRoom room)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_rooms[y,x] != null && _rooms[y, x].Equals(room))
                    {
                        return (y, x);
                    }
                }
            }
            throw new ArgumentException();
        }

        public int CoinCount
        {
            get
            {
                int count = 0;
                foreach (var room in _rooms)
                {
                    if (room != null && room.Content.ElementName == Keys.CoinKey)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public IEnumerable<IRoom> GetEnumerable()
        {
            foreach (var room in _rooms)
            {
                yield return room;
            }
        }
    }
}
