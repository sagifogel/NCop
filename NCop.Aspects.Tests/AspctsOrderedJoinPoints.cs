using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Tests.Extensions;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    public abstract class AbstrtactAspectOrderedJoinPoints : List<AspectJoinPoints>
    {
        public override string ToString() {
            return this.Stringify();
        }
    }

    public class OnMethodBoundaryAspectOrderedJoinPoints : AbstrtactAspectOrderedJoinPoints
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

    public class MultipleOnMethodBoundaryAspectOrderedJoinPoints : AbstrtactAspectOrderedJoinPoints
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

    public class MultipleInterceptionAspectOrderedJoinPoints : AbstrtactAspectOrderedJoinPoints
    {
        public MultipleInterceptionAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
        }
    }

    public class AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect : AbstrtactAspectOrderedJoinPoints
    {
        public AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class AllAspectOrderedJoinPointsStartingWithInterceptionAspect : AbstrtactAspectOrderedJoinPoints
    {
        public AllAspectOrderedJoinPointsStartingWithInterceptionAspect() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnSuccess);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints : AbstrtactAspectOrderedJoinPoints
    {
        public WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnEntry);
            Add(AspectJoinPoints.InMethod);
            Add(AspectJoinPoints.OnException);
            Add(AspectJoinPoints.OnExit);
        }
    }

    public class AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect : AbstrtactAspectOrderedJoinPoints
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

    public class AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect : AbstrtactAspectOrderedJoinPoints
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

    public class InterceptionAspectOrderedJoinPoints : AbstrtactAspectOrderedJoinPoints
    {
        public InterceptionAspectOrderedJoinPoints() {
            Add(AspectJoinPoints.OnInvoke);
            Add(AspectJoinPoints.InMethod);
        }
    }
}
