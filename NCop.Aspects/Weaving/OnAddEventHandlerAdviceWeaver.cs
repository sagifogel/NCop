
namespace NCop.Aspects.Weaving
{
    internal class OnAddEventHandlerAdviceWeaver : AbstractAdviceWeaver
    {
        public OnAddEventHandlerAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnAddHandler";
            }
        }
    }
}