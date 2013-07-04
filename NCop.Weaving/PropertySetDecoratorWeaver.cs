using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertySetDecoratorWeaver : AbstractMethodWeaver, IPropertySetWeaver
    {
        public PropertySetDecoratorWeaver(MethodInfo methodInfoImpl, Type implementationType, Type contractType)
            : base(methodInfoImpl, implementationType, contractType) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodDefintionWeaver = new PropertySetSignatureWeaver();
            MethodScopeWeaver = new PropertySetDecoratorScopeWeaver(methodInfoImpl, implementationType, contractType);
        }
    }
}
