
namespace NCop.Aspects.Weaving
{
    internal class OnRemoveHandlerAdviceWeaver : AbstractAdviceWeaver
    {
        public OnRemoveHandlerAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnRemoveHandler";
            }
        }
    }
}