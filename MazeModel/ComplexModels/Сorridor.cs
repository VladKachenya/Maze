using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases;

namespace MazeModel.ComplexModels
{
    public class Сorridor : ComplexModelBase, IOriented
    {
        public Сorridor(Direction sideEntity1, ModelBase Entity1, ModelBase Entity2)
            : base(Keys.СorridorKey)
        {
            switch (sideEntity1)
            {
                case Direction.Down:
                    this._naighborDictionarys.Add(sideEntity1, Entity1);
                    this._naighborDictionarys.Add(Direction.Up, Entity2);
                    IsHorizontal = false;
                    break;
                case Direction.Up:
                    this._naighborDictionarys.Add(sideEntity1, Entity1);
                    this._naighborDictionarys.Add(Direction.Down, Entity2);
                    IsHorizontal = false;
                    break;
                case Direction.Left:
                    this._naighborDictionarys.Add(sideEntity1, Entity1);
                    this._naighborDictionarys.Add(Direction.Right, Entity2);
                    IsHorizontal = true;
                    break;
                case Direction.Right:
                    this._naighborDictionarys.Add(sideEntity1, Entity1);
                    this._naighborDictionarys.Add(Direction.Left, Entity2);
                    IsHorizontal = true;
                    break;
            }
        }

        public bool IsHorizontal { get; }
    }
}