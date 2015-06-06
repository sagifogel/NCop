using NCop.Core;
using NCop.IoC;
using NCop.Mixins.Engine;
using NCop.Weaving;
using System;

namespace NCop.Mixins.Weaving
{
    public abstract class AbstrcatMixinsTypeWeaverBuilder : AbstractTypeWeaverBuilder, IMixinMapBag
    {
        protected readonly TypeMapSet mixinsMap = null;
        protected readonly INCopDependencyAwareRegistry registry = null;

        protected AbstrcatMixinsTypeWeaverBuilder(Type type, INCopDependencyAwareRegistry registry)
            : base(type) {
            this.registry = registry;
            mixinsMap = new TypeMapSet();
        }

        public virtual void Add(TypeMap item) {
            mixinsMap.Add(item);
        }
    }
}
