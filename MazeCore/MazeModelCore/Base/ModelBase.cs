using System;
using MazeModelCore.Interfases.Base;

namespace MazeModelCore.Base
{
    public abstract class ModelBase : IModelBase
    {
        public string ElementName { get;}

        protected ModelBase(string elementName)
        {
            if (elementName == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrWhiteSpace(elementName))
            {
                throw new ArgumentException();
            }
            ElementName = elementName;
        }
    }
}
