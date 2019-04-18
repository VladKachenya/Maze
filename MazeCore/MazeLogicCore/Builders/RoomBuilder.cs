using MazeLogicCore.Interfases.Builders;
using MazeModelCore.ComplexModels;
using MazeModelCore.Interfases.ComplexModels;

namespace MazeLogicCore.Builders
{
    public class RoomBuilder : IBuilder
    {
        public void Build(IMaze maze)
        {
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    maze[y, x] = new Room();
                }
            }
        }
    }
}