using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MixinTypeWeaver : IMixinTypeWeaver
    {
        public MixinTypeWeaver(Type decoratedType, Type @interface) {
            Type = decoratedType;
            Interface = @interface;
        }

        public Type Type { get; private set; }

        public Type Interface { get; private set; }
        
        public TypeBuilder TypeBuilder { get; set; }

        public IEnumerable<IMethodWeaver> MethodWeavers { get; private set; }
    
        void IWeaver.Weave() {
            throw new NotImplementedException();
        }
    }
}
