using MazeModel.Helper;
using MazeModel.Interfases;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MazeModel.ComplexModels
{
    public class Maze : IMaze
    {
        private Room[,] _rooms;

        public Maze(int height, int width)
        {
            Width = width;
            Height = height;
            _rooms = new Room[Height, Width];
        }
        public int Width { get; }
        public int Height { get; }

        public Room this[int y, int x]
        {
            get => _rooms[y, x];
            set => _rooms[y, x] = value;
        }

        public (int, int) GetIndex(Room room)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_rooms[y, x].Equals(room))
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
                    if (room.Content.ElementName == Keys.CoinKey)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public IEnumerable<Room> GetEnumerable()
        {
            foreach (var room in _rooms)
            {
                yield return room;
            }
        }
    }
}
