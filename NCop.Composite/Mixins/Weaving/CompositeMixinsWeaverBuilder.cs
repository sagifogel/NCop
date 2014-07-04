using NCop.Composite.Weaving;
using NCop.IoC;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.Mixins.Weaving
{
    internal class CompositeMixinsWeaverBuilder : MixinsTypeWeaverBuilder, ICompositeMixinsTypeWeaverBuilder
    {
        public CompositeMixinsWeaverBuilder(Type type, ITypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, typeDefinition, registry) {
        }
    }
}
