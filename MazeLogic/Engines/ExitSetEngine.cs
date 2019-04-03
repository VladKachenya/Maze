using MazeLogic.Interfases.Engines;
using MazeModel.ComplexModels;
using MazeModel.Helper;
using MazeModel.Interfases;
using System;

namespace MazeLogic.Engines
{
    public class ExitSetEngine : IEngine
    {
        private readonly IMaze _maze;
        private Random _random;
        private bool isExitBuild;


        public ExitSetEngine(IMaze maze)
        {
            _maze = maze;
            _random = new Random();
            isExitBuild = false;


        }
        public void Move(Direction direction)
        {


            if (!isExitBuild && _maze.CoinCount == 0)
            {
                isExitBuild = true;
                switch (_random.Next(2))
                {
                    case 0:
                        {
                            var room = _maze[_random.Next(_maze.Height), 0];
                            room.SetNeighbor(new Exit(), Direction.Left);
                            break;
                        }
                    case 1:
                        {
                            var room = _maze[_maze.Height - 1, _random.Next(_maze.Width)];
                            room.SetNeighbor(new Exit(), Direction.Down);
                            break;
                        }
                    case 2:
                        {
                            var room = _maze[_random.Next(_maze.Height), _maze.Width - 1];
                            room.SetNeighbor(new Exit(), Direction.Right);
                            break;
                        }
                    case 3:
                        {
                            var room = _maze[0, _random.Next(_maze.Width)];
                            room.SetNeighbor(new Exit(), Direction.Up);
                            break;
                        }
                }
            }
        }
    }
}