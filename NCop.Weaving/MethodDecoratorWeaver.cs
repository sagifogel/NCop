using System.Reflection;

namespace NCop.Weaving
{
    public class MethodDecoratorWeaver : AbstractMethodWeaver
    {
		public MethodDecoratorWeaver(MethodInfo method, IWeavingSettings weavingSettings)
			: base(method, weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new MethodDecoratorScopeWeaver(method, weavingSettings);
			MethodDefintionWeaver = new MethodSignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
