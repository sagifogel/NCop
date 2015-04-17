
namespace NCop.Aspects.Weaving
{
    internal class OnInvokeHandlerAdviceWeaver : AbstractAdviceWeaver
    {
        public OnInvokeHandlerAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnInvokeHandler";
            }
        }
    }
}