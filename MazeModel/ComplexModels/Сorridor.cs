using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases;

namespace MazeModel.ComplexModels
{
    public class Сorridor : ComplexModelBase, IOriented
    {
        public Сorridor(Direction sideEntity1, ModelBase entity1, ModelBase entity2)
            : base(Keys.СorridorKey)
        {
            switch (sideEntity1)
            {
                case Direction.Down:
                    this._naighborDictionarys.Add(sideEntity1, entity1);
                    this._naighborDictionarys.Add(Direction.Up, entity2);
                    IsHorizontal = false;
                    break;
                case Direction.Up:
                    this._naighborDictionarys.Add(sideEntity1, entity1);
                    this._naighborDictionarys.Add(Direction.Down, entity2);
                    IsHorizontal = false;
                    break;
                case Direction.Left:
                    this._naighborDictionarys.Add(sideEntity1, entity1);
                    this._naighborDictionarys.Add(Direction.Right, entity2);
                    IsHorizontal = true;
                    break;
                case Direction.Right:
                    this._naighborDictionarys.Add(sideEntity1, entity1);
                    this._naighborDictionarys.Add(Direction.Left, entity2);
                    IsHorizontal = true;
                    break;
            }
        }

        public bool IsHorizontal { get; }
    }
}