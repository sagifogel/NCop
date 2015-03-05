using NCop.Aspects.Advices;

namespace NCop.Aspects.Weaving
{
    public class AdviceDiscoveryVisitor
    {
        internal bool HasFinallyAdvice { get; private set; }

        internal bool HasOnSetPropertyAdvice { get; private set; }

        internal bool HasOnGetPropertyAdvice { get; private set; }
        
        internal bool HasOnMethodEntryAdvice { get; private set; }

        internal bool HasOnMethodInvokeAdvice { get; private set; }

        internal bool HasOnMethodSuccessAdvice { get; private set; }

        internal bool HasOnMethodExceptionAdvice { get; private set; }

        internal FinallyAdviceAttribute FinallyAdvice { get; private set; }

        internal OnMethodEntryAdviceAttribute OnMethodEntryAdvice { get; private set; }

        internal OnGetPropertyAdviceAttribute OnGetPropertyAdvice { get; private set; }

        internal OnSetPropertyAdviceAttribute OnSetPropertyAdvice { get; private set; }
        
        internal OnMethodInvokeAdviceAttribute OnMethodInvokeAdvice { get; private set; }

        internal OnMethodSuccessAdviceAttribute OnMethodSuccessAdvice { get; private set; }

        internal OnMethodExceptionAdviceAttribute OnMethodExceptionAdvice { get; private set; }

        internal void Visit(FinallyAdviceAttribute advice) {
            FinallyAdvice = advice;
            HasFinallyAdvice = true;
        }

        internal void Visit(OnMethodEntryAdviceAttribute advice) {
            OnMethodEntryAdvice = advice;
            HasOnMethodEntryAdvice = true;
        }

        internal void Visit(OnMethodInvokeAdviceAttribute advice) {
            OnMethodInvokeAdvice = advice;
            HasOnMethodInvokeAdvice = true;
        }

        internal void Visit(OnMethodSuccessAdviceAttribute advice) {
            OnMethodSuccessAdvice = advice;
            HasOnMethodSuccessAdvice = true;
        }

        internal void Visit(OnMethodExceptionAdviceAttribute advice) {
            OnMethodExceptionAdvice = advice;
            HasOnMethodExceptionAdvice = true;
        }

		internal void Visit(OnGetPropertyAdviceAttribute advice) {
			OnGetPropertyAdvice = advice;
            HasOnGetPropertyAdvice = true;
        }

        internal void Visit(OnSetPropertyAdviceAttribute advice) {
            OnSetPropertyAdvice = advice;
            HasOnSetPropertyAdvice = true;
        }
    }
}
