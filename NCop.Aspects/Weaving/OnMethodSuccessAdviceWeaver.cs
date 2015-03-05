
namespace NCop.Aspects.Weaving
{
    internal class OnMethodSuccessAdviceWeaver : AbstractAdviceWeaver
    {
        public OnMethodSuccessAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnSuccess";
            }
        }
    }
}
