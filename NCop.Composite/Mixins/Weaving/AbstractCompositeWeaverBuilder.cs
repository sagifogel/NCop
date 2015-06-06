using NCop.Aspects.Weaving;
using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using System;

namespace NCop.Composite.Mixins.Weaving
{
    internal abstract class AbstractCompositeWeaverBuilder : AbstrcatMixinsTypeWeaverBuilder
    {
        protected readonly IAspectTypeDefinition typeDefinition = null;

        public AbstractCompositeWeaverBuilder(Type type, IAspectTypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, registry) {
            this.typeDefinition = typeDefinition;
        }

        public override abstract ITypeWeaver Build();

        public override void AddEventWeaver(IEventWeaver eventWeaver) {
            IMethodWeaver onInvokeMethod = null;
            var compositeEventWeaver = eventWeaver as ICompositeEventWeaver;

            base.AddEventWeaver(eventWeaver);
            onInvokeMethod = compositeEventWeaver.GetOnInvokeMethod();

            if (onInvokeMethod.IsNotNull()) {
                methodWeavers.Add(onInvokeMethod);
            }
        }
    }
}
