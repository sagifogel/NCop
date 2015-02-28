
namespace NCop.Aspects.Weaving
{
    internal class FinallyAdviceWeaver : AbstractAdviceWeaver
    {
        public FinallyAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings)
            : base(adviceWeavingSettings) {
        }

        protected override string AdviceName {
            get {
                return "OnExit";
            }
        }
    }
}