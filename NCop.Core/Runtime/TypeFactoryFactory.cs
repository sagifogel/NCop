using NCop.Core.Extensions;

namespace NCop.Core.Runtime
{
    public static class TypeFactoryFactory
    {
        public static ITypeFactory Get(IRuntimeSettings settings) {
            settings = settings ?? new RuntimeSettings();

            if (settings.Types.IsNotNullOrEmpty()) {
                return new TypeFactory(settings.Types);
            }

            return new FromAssembliesTypeFacotry(settings.Assemblies);
        }
    }
}
