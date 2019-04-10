using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeModel.Interfases.Base;

namespace MazeModel.Base
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
