
namespace NCop.Aspects.Weaving
{
    internal class OnMethodExceptionAdviceWeaver : AbstractAdviceWeaver
    {
        public OnMethodExceptionAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnException";
            }
        }
    }
}
