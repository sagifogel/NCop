using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Weaving.Responsibility
{
    public class MethodDecoratorWeaverHandler : AbstractMethodWeaverHandler
    {
        public MethodDecoratorWeaverHandler(Type type)
            : base(type) {
        }

        public override IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return null;
        }
    }
}
