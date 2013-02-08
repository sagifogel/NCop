using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public class MethodDecoratorWeaverHandler : AbstractMethodWeaverHandler
    {
        public MethodDecoratorWeaverHandler(Type type)
            : base(type) {
            CanHandle = true;
        }

        public override bool CanHandle { get; protected set; }

        public override IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return HandleInternal(methodInfo, typeDefinition);
        }

        protected override IMethodWeaver HandleInternal(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return new MethodDecoratorWeaver(methodInfo, Type);
        }
    }
}
