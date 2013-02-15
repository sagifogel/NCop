using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using NCop.Aspects.Pointcuts;
using NCop.Aspects.Engine;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Core.Extensions;
using NCop.Aspects.JoinPoints;

namespace NCop.Aspects.Aspects
{
    public abstract class AspectDefinition : IAspectDefinition
    {
        protected readonly JoinPointMetadata JoinPointMetadata = null;
        protected readonly AdviceVisitor AdviceVisitor = new AdviceVisitor();
        protected readonly AdviceCollection AdviceCollection = new AdviceCollection();

        public AspectDefinition(IAspectProvider provider, JoinPointMetadata joinPointMetadata, int aspectPriority) {
            Aspect = provider.Aspect;
            AspectPriority = aspectPriority;
            JoinPointMetadata = joinPointMetadata;
            BulidAdvices();
        }

        public IAspect Aspect { get; private set; }

        public IAdviceCollection Advices {
            get {
                return AdviceCollection;
            }
        }

        public int AspectPriority { get; private set; }
        
        protected abstract void BulidAdvices();
     }
}
