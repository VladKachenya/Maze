using MazeLogicCore.Interfases.Converters;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Models;

namespace MazeLogicCore.Converters
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
            if (element is IComplexModelBase @base)
            {
               return @base.Content;
            }
            return element;
        }
    }
}