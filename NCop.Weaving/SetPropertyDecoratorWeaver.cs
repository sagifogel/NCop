using System.Reflection;

namespace NCop.Weaving
{
    public class SetPropertyDecoratorWeaver : AbstractMethodWeaver, ISetPropertyWeaver
    {
		public SetPropertyDecoratorWeaver(MethodInfo methodInfo, IWeavingSettings weavingSettings)
            : base(methodInfo, weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new SetPropertyDecoratorScopeWeaver(methodInfo, weavingSettings);
			MethodDefintionWeaver = new SetPropertySignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
