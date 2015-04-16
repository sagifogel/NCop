using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    internal class EventInterceptionAspectDefinition : IAspectDefinition
    {
        public IAspect Aspect {
            get { throw new NotImplementedException(); }
        }

        public System.Reflection.MethodInfo Method {
            get { throw new NotImplementedException(); }
        }

        public Engine.AspectType AspectType {
            get { throw new NotImplementedException(); }
        }

        public IAspectDefinition BuildAdvices() {
            throw new NotImplementedException();
        }

        public Type AspectDeclaringType {
            get { throw new NotImplementedException(); }
        }

        public Advices.IAdviceDefinitionCollection Advices {
            get { throw new NotImplementedException(); }
        }

        public Weaving.Expressions.IAspectExpressionBuilder Accept(Weaving.Expressions.IAspectDefinitionVisitor visitor) {
            throw new NotImplementedException();
        }
    }
}
