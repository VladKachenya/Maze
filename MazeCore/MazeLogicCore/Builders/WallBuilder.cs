using MazeLogicCore.Interfases.Builders;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Models;

namespace MazeLogicCore.Builders
{
    public class WallBuilder : IBuilder
    {
        public void Build(IMaze maze)
        {
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    maze[y, x].SetNeighbor( new Wall(), Direction.Left);
                    maze[y, x].SetNeighbor(new Wall(), Direction.Up);
                    if (x != 0)
                    {
                        maze[y, x - 1].SetNeighbor(maze[y, x][Direction.Left], Direction.Right);
                    }

                    if (x == maze.Width - 1)
                    {
                        maze[y, x].SetNeighbor(new Wall(), Direction.Right);
                    }

                    if (y != 0)
                    {
                        maze[y - 1, x].SetNeighbor(maze[y, x][Direction.Up], Direction.Down);
                    }

                    if (y == maze.Height - 1)
                    {
                        maze[y, x].SetNeighbor(new Wall(), Direction.Down);
                    }


                }
            }
        }
    }
}