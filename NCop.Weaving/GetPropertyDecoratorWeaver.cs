using System.Reflection;

namespace NCop.Weaving
{
    public class GetPropertyDecoratorWeaver : AbstractMethodWeaver
    {
        public GetPropertyDecoratorWeaver(MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new GetPropertyDecoratorScopeWeaver(method, weavingSettings);
			MethodDefintionWeaver = new GetPropertySignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
