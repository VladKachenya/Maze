﻿using MazeModel.Base;
using MazeModel.Helper;
using MazeModel.Interfases.Base;
using System.Collections.Generic;
using System.Linq;
using MazeModel.Interfases.ComplexModels;

namespace MazeModel.ComplexModels
{
    public class Room : ComplexModelBase, IRoom
    {

        public Room() : base(Keys.RoomKey)
        {
        }

        public void SetNeighbor(IModelBase modelBase, Direction key)
        {
            _naighborDictionarys.Remove(key);
            this._naighborDictionarys.Add(key, modelBase);
        }

        public bool IsSealed
        {
            get
            {
                if (_naighborDictionarys.Count == 0) return false;
                if (this[Direction.Down] == null) return false;
                if (this[Direction.Up] == null) return false;
                if (this[Direction.Left] == null) return false;
                if (this[Direction.Right] == null) return false;
                return _naighborDictionarys.All(el => el.Value.ElementName == Keys.WallKey);
            }
        }

        public IEnumerable<KeyValuePair<Direction, IModelBase>> GetEnumerable()
        {
            return _naighborDictionarys;
        }
    }
}