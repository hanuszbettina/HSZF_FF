using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesFeladatDomain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ToExportAttribute:Attribute
    {
        public string ElementName { get; }

        // Konstruktor az osztály nevét vagy az export elem nevét tartalmazó paraméterrel
        public ToExportAttribute(string elementName)
        {
            ElementName = elementName;
        }
    }
}
