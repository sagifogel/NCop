using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public interface IPropertyWeaver : IWeaver
    {
        IPropertyGetWeaver PropertyGetWeaver { get; }
        IPropertySetWeaver PropertySetWeaver { get; }
    }
}
