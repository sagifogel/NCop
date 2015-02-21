using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.Engine
{
    internal class CompositePropertyMapVisitor : ICompositePropertyMapVisitor
    {
        public IPropertyWeaverBuilder Visit(GetCompositePropertyMap propertyMap) {
            throw new NotImplementedException();
        }

        public IPropertyWeaverBuilder Visit(SetCompositePropertyMap propertyMap) {
            throw new NotImplementedException();
        }
    }
}
