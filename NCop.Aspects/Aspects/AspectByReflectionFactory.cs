using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    public class AspectByReflectionFactory : IAspectFactory
    {
        private Type _type = null;

        public AspectByReflectionFactory(Type type) {
            _type = type;
        }

        public IAspect Create() {
            return (IAspect)Activator.CreateInstance(_type);
        }
    }
}
