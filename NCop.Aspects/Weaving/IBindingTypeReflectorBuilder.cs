
namespace NCop.Aspects.Weaving
{
    public interface IBindingTypeReflectorBuilder
    {
        IBindingTypeReflector Build(IAspectWeavingSettings aspectsWeavingSettings);
    }
}
