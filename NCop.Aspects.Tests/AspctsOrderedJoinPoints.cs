using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Tests.Extensions;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Tests
{
    public class ReturnValueAspectOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public ReturnValueAspectOrderedJoinPoints(IEnumerable<AspectJoinPoints> joinPoints) {
            var index = joinPoints.IndexOf(jp => jp == AspectJoinPoints.InMethod);

            AddRange(joinPoints.Skip(index));
        }
    }

    public class AspectOrderedJoinPoints : List<AspectJoinPoints>
    {
        public int Calculate() {
            return this.Sum(jp => (int)jp);
        }

        public override string ToString() {
            return this.Stringify();
        }
    }

    public class OnMethodBoundaryAspectOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public OnMethodBoundaryAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }

        public override string ToString() {
            return base.ToString();
        }
    }

    public class MultipleOnMethodBoundaryAspectOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public MultipleOnMethodBoundaryAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class MultipleInterceptionAspectOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public MultipleInterceptionAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
        }
    }

    public class AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect : AspectOrderedJoinPoints
    {
        public AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class AllAspectOrderedJoinPointsStartingWithInterceptionAspect : AspectOrderedJoinPoints
    {
        public AllAspectOrderedJoinPointsStartingWithInterceptionAspect() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnException);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
        }
    }

    public class OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
        }
    }

    public class AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect : AspectOrderedJoinPoints
    {
        public AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect : AspectOrderedJoinPoints
    {
        public AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class InterceptionAspectOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public InterceptionAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
        }
    }

    public class InterceptionAspectUsingInvokeOrderedJoinPoints : AspectOrderedJoinPoints
    {
        public InterceptionAspectUsingInvokeOrderedJoinPoints() {
            Add(AspectJoinPoints.InMethod);
        }
    }
}
