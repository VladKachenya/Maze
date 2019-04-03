using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeModel.Base
{
    public abstract class ModelBase
    {
        public string ElementName { get; protected set; }

        public ModelBase(string elementName)
        {
            ElementName = elementName;
        }
    }
}
