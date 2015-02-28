using System.Reflection;

namespace NCop.Weaving
{
    public class MethodDecoratorWeaver : AbstractMethodWeaver
    {
		public MethodDecoratorWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings)
			: base(methodInfo, weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new MethodDecoratorScopeWeaver(methodInfo, weavingSettings);
			MethodDefintionWeaver = new MethodSignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
