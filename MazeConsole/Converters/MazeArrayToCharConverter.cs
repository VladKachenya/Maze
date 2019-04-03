using MazeLogic.Converters;
using MazeLogic.Interfases.Converters;
using MazeModel.Base;
using MazeModel.ComplexModels;
using MazeModel.Helper;
using MazeModel.Interfases;

namespace MazeConsole.Converters
{
    public class MazeToCharConverter : IConverter<IMaze, char[,]>
    {
        private IConverter<IMaze, ModelBase[,]> _modelToArrComverter;
        public MazeToCharConverter()
        {
            _modelToArrComverter = new MazeToEntityArrayConverter();
        }
        public char[,] Convert(IMaze mazeObject)
        {
            var maze = _modelToArrComverter.Convert(mazeObject);
            var res = new char[maze.GetUpperBound(0) + 1, maze.GetUpperBound(1) + 1];
            for (int y = 0; y < maze.GetUpperBound(0) + 1; y++)
            {
                for (int x = 0; x < maze.GetUpperBound(1) + 1; x++)
                {
                    res[y, x] = EntityToCharConverter(maze[y, x]);
                }
            }
            return res;
        }
        private char EntityToCharConverter(ModelBase modelBase)
        {
            switch (modelBase?.ElementName)
            {
                case Keys.RoomKey: return ' ';
                case Keys.WallKey: return '#';
                case Keys.СorridorKey: return ' ';; // (modelBase as Сorridor).IsHorizontal ? '-' : '|';
                case Keys.ColumnKey: return 'o';
                case Keys.CoinKey: return '0';
                case Keys.HeroKey: return 'X';
                case Keys.ExitKey: return ' ';
                default: return '?';
            }
        }
    }
}
