using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases;

namespace MazeModel.ComplexModels
{
    public class Room : ComplexModelBase
    {

        public Room() : base(Keys.RoomKey)
        {
        }

        public void SetNeighbor(ModelBase modelBase, Direction key)
        {
            _naighborDictionarys.Remove(key);
            this._naighborDictionarys.Add(key, modelBase);
        }

        public bool IsSealed => _naighborDictionarys.All(el => el.Value.ElementName == Keys.WallKey);

        public IEnumerable<KeyValuePair<Direction, ModelBase>> GetEnumerable()
        {
            return _naighborDictionarys;
        }
    }
}