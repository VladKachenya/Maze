using MazeLogic.Interfases.Builders;
using MazeModel.ComplexModels;
using MazeModel.Helper;
using MazeModel.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using MazeModel.Interfases.Base;
using MazeModel.Interfases.ComplexModels;

namespace MazeLogic.Builders
{
    public class CorridorBuilder : IBuilder
    {
        private readonly Func<Direction, IModelBase, IModelBase, IModelBase> _corridorFactoryFunc;
        private IMaze _maze;
        private Random rand = new Random();

        public CorridorBuilder(Func<Direction, IModelBase, IModelBase, IModelBase> corridorFactoryFunc)
        {
            _corridorFactoryFunc = corridorFactoryFunc;
        }

        public void Build(IMaze maze)
        {
            _maze = maze;
            BuildCorridors(_maze[0,0]);
        }


        protected void BuildCorridors(IRoom startRoom)
        {
            var startCell = startRoom;
            var currentCell = startCell;
            Stack<IRoom> cells = new Stack<IRoom>();
            do
            {
                var neighbors = GetAllSealedNeighbors(currentCell);
                if (neighbors.Count != 0)
                {
                    var nextCell = GetRandomCell(neighbors);
                    BrokeWall(currentCell, nextCell);
                    cells.Push(currentCell);
                    currentCell = nextCell;
                }
                else if (cells.Count != 0)
                {
                    currentCell = cells.Pop();
                }
                else
                {
                    return;
                }
            } while (true);
        }

        protected List<IRoom> GetAllSealedNeighbors(IRoom room)
        {
            var res = new List<IRoom>();
            var pos = _maze.GetIndex(room);
            if (pos.Item1 - 1 >= 0 && _maze[pos.Item1 - 1, pos.Item2].IsSealed)
            {
                res.Add(_maze[pos.Item1 - 1, pos.Item2]);
            }
            if (pos.Item1 + 1 < _maze.Height && _maze[pos.Item1 + 1, pos.Item2].IsSealed)
            {
                res.Add(_maze[pos.Item1 + 1, pos.Item2]);
            }
            if (pos.Item2 - 1 >= 0 && _maze[pos.Item1, pos.Item2 - 1].IsSealed)
            {
                res.Add(_maze[pos.Item1, pos.Item2 - 1]);
            }
            if (pos.Item2 + 1 < _maze.Width && _maze[pos.Item1, pos.Item2 + 1].IsSealed)
            {
                res.Add(_maze[pos.Item1, pos.Item2 + 1]);
            }
            return res;
        }

        protected void BrokeWall(IRoom room1, IRoom room2)
        {
            IModelBase door;
            var room1Sides = room1.GetEnumerable();
            var room2Sides = room2.GetEnumerable();
            Direction side = (Direction) 0;
            foreach (var element in room1Sides)
            {
                if (room2Sides.Any(el => el.Value == element.Value))
                {
                    side = element.Key;
                    break;
                }
            }

            switch (side)
            {
                case Direction.Up:
                    {
                        door =  _corridorFactoryFunc(Direction.Down, room1, room2);
                        room1.SetNeighbor(door, Direction.Up);
                        room2.SetNeighbor(door, Direction.Down);
                        break;
                    }
                case Direction.Down:
                    {
                        door = _corridorFactoryFunc(Direction.Up, room1, room2);
                        room1.SetNeighbor(door, Direction.Down);
                        room2.SetNeighbor(door, Direction.Up);
                        break;
                    }
                case Direction.Right:
                    {
                        door = _corridorFactoryFunc(Direction.Left, room1, room2);
                        room1.SetNeighbor(door, Direction.Right);
                        room2.SetNeighbor(door, Direction.Left);
                        break;
                    }
                case Direction.Left:
                    {
                        door = _corridorFactoryFunc(Direction.Right, room1, room2);
                        room1.SetNeighbor(door, Direction.Left);
                        room2.SetNeighbor(door, Direction.Right);
                        break;
                    }
                default: throw new ArgumentException();
            }
        }
        protected IRoom GetRandomCell(List<IRoom> rooms)
        {
            var randIdnex = rand.Next(rooms.Count);
            return rooms[randIdnex];
        }
    }
}