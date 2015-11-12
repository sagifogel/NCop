using NCop.Core;

namespace NCop.IoC
{
    public interface INCopDependencyAwareRegistry
    {
        void Register(TypeMap typeMap, ITypeMapCollection dependencies = null, bool isComposite = false);
    }
}
