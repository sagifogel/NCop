using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal interface IMethodBindingWeaver : IWeaver
    {
        FieldInfo Weave();
    }
}
