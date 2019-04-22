using MazeLogicCore.Interfases.Converters;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;
using MazeModelCore.Interfases.ComplexModels;

namespace MazeLogicCore.Converters
{
    public class MazeToCharConverter : IMazeToCharConverter
    {
        private IConverter<IMaze, IModelBase[,]> _modelToArrComverter;
        public MazeToCharConverter(IConverter<IMaze, IModelBase[,]> modelToArrComverter)
        {
            _modelToArrComverter = modelToArrComverter;
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
        private char EntityToCharConverter(IModelBase modelBase)
        {
            switch (modelBase?.ElementName)
            {
                case Keys.RoomKey: return ' ';
                case Keys.WallKey: return '#';
                case Keys.СorridorKey: return ' '; ; // (modelBase as Сorridor).IsHorizontal ? '-' : '|';
                case Keys.ColumnKey: return 'o';
                case Keys.CoinKey: return '0';
                case Keys.HeroKey: return 'X';
                case Keys.ExitKey: return ' ';
                default: return '?';
            }
        }
    }
}