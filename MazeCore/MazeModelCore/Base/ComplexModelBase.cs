using System.Collections.Generic;
using MazeModelCore.Helper;
using MazeModelCore.Interfases.Base;

namespace MazeModelCore.Base
{
    public abstract class ComplexModelBase : ModelBase, IComplexModelBase
    {
        protected Dictionary<Direction, IModelBase> _naighborDictionarys;
        private IModelBase _content;

        public ComplexModelBase(string elementName) : base(elementName)
        {
            _naighborDictionarys = new Dictionary<Direction, IModelBase>();
        }

        public IModelBase Content
        {
            get => _content == null ? this: _content;
            set
            {
                IsEmpty = value == null;
                _content = value;
            }
        }

        public bool IsEmpty { get; protected set; } = true;

        public IModelBase this[Direction direction]
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