
namespace NCop.Aspects.Weaving
{
    internal class OnRemoveEventHandlerAdviceWeaver : AbstractAdviceWeaver
    {
        public OnRemoveEventHandlerAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnRemoveHandler";
            }
        }
    }
}