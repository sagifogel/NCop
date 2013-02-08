using NCop.Aspects.Aspects;
using NCop.Core.Weaving;
using NCop.Core.Weaving.Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class AspectMethodWeaverHandler : AbstractMethodWeaverHandler
    {
        public AspectMethodWeaverHandler(Type type)
            : base(type) {
            CanHandle = KnownAspects.IsAspect(type);
        }

        public override bool CanHandle { get; protected set; }

        protected override IMethodWeaver HandleInternal(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            return null;
        }
    }
}
