using MazeLogic.Interfases.Converters;
using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases;
using MazeModel.Interfases.Base;
using MazeModel.Models;

namespace MazeLogic.Converters
{
    public class MazeToEntityArrayConverter : IConverter<IMaze, IModelBase[,]>
    {
        public IModelBase[,] Convert(IMaze maze)
        {
            int height = maze.Height * 2 + 1;
            int width = maze.Width * 2 + 1;
            IModelBase[,] res = new IModelBase[height, width];
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    res[y * 2 + 1, x * 2 + 1] = GetContent(maze[y, x].Content);
                    res[y * 2, x * 2 + 1] = GetContent( maze[y, x][Direction.Up]);
                    res[y * 2 + 1, x * 2] = GetContent(maze[y, x][Direction.Left]);
                    res[(y + 1) * 2, x * 2 + 1] = GetContent(maze[y, x][Direction.Down]);
                    res[y * 2 + 1, (x + 1) * 2] = GetContent(maze[y, x][Direction.Right]);
                }
            }
            // Расстановка колон на пустые места
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (res[y, x] == null)
                        res[y, x] = new Column();
                }
            }
            return res;
        }

        private IModelBase GetContent(IModelBase element)
        {
            if (element is ComplexModelBase @base)
            {
               return @base.Content;
            }
            return element;
        }
    }
}