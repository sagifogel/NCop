
namespace NCop.Aspects.Weaving.Expressions
{
	public interface IAspectExpression
	{
		IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings);
	}
}
