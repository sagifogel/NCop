
namespace NCop.Aspects.Weaving
{
    internal class OnGetPropertyAdviceWeaver : AbstractAdviceWeaver
    {
        internal OnGetPropertyAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnGetValue";
            }
        }
    }
}
