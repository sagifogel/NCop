
namespace NCop.Aspects.Weaving
{
    internal class OnMethodEntryAdviceWeaver : AbstractAdviceWeaver
    {
        public OnMethodEntryAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnEntry";
            }
        }
    }
}
