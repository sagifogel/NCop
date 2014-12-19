
namespace NCop.Aspects.Weaving
{
    internal class OnSetPropertyAdviceWeaver : AbstractAdviceWeaver
    {
        internal OnSetPropertyAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnSetValue";
            }
        }
    }
}
