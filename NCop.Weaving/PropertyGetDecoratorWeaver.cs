using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public class PropertyGetDecoratorWeaver : AbstractMethodWeaver, IPropertyGetWeaver
    {
        public PropertyGetDecoratorWeaver(MethodInfo methodInfo, Type implementationType, Type contractType)
            : base(methodInfo, implementationType, contractType) {
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineMethod(ITypeDefinition typeDefinition) {
            throw new NotImplementedException();
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            throw new NotImplementedException();
        }
    }
}
