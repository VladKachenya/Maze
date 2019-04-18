using System;

namespace MazeGameConsole.Drawer
{
    public class SimpleDrawer
    {

        public void Draw(char[,] maze)
        {
            Console.Clear();
            int height = maze.GetUpperBound(0) + 1;
            int width = maze.GetUpperBound(1) + 1;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(maze[y, x]);
                }
                Console.WriteLine();
            }
        }


    }
}