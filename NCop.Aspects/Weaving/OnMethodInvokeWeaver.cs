
namespace NCop.Aspects.Weaving
{
    internal class OnMethodInvokeWeaver : AbstractAdviceWeaver
    {
        internal OnMethodInvokeWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnInvoke";
            }
        }
    }
}
