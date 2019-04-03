using MazeModel.Helper;
using MazeModel.Interfases;
using System;
using System.Collections.Generic;

namespace MazeModel.Base
{
    public abstract class ComplexModelBase : ModelBase, IEntityContaining
    {
        protected Dictionary<Direction, ModelBase> _naighborDictionarys;
        private ModelBase _content;

        public ComplexModelBase(string elementName) : base(elementName)
        {
            _naighborDictionarys = new Dictionary<Direction, ModelBase>();
        }

        public ModelBase Content
        {
            get => _content == null ? this: _content;
            set
            {
                IsEmpty = value == null;
                _content = value;
            }
        }

        public bool IsEmpty { get; protected set; } = true;

        public ModelBase this[Direction direction]
        {
            get
            {
                if (!_naighborDictionarys.ContainsKey(direction))
                {
                    return null;
                }
                return _naighborDictionarys[direction];
            }
        }


    }
}