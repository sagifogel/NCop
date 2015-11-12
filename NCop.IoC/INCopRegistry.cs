using NCop.Core;

namespace NCop.IoC
{
    public interface INCopRegistry
    {
        void Register(TypeMap typeMap, ITypeMapCollection dependencies = null);
    }
}