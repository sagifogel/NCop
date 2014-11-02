using NCop.Weaving;

namespace NCop.Composite.Weaving
{
	public class CompositePropertyWeaver : AbstractMethodWeaver
	{
		public CompositePropertyWeaver(IMethodWeavingSettings weavingSettings)
			: base(weavingSettings) {
		}
	}
}
