
namespace NCop.Aspects.Weaving
{
    internal class OnAddHandlerAdviceWeaver : AbstractAdviceWeaver
    {
        public OnAddHandlerAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnAddHandler";
            }
        }
    }
}