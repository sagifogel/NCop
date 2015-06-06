using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    public abstract class AbstractAspectWeaverBuilder
    {
        protected readonly Type contractType = null;
        protected readonly IAspectTypeDefinition typeDefinition = null;

        protected AbstractAspectWeaverBuilder(Type contractType, IAspectTypeDefinition typeDefinition) {
            this.contractType = contractType;
            this.typeDefinition = typeDefinition;
        }
    }
}
