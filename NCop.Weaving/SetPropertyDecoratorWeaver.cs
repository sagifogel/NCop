using System.Reflection;

namespace NCop.Weaving
{
    public class SetPropertyDecoratorWeaver : AbstractMethodWeaver
    {
		public SetPropertyDecoratorWeaver(MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new SetPropertyDecoratorScopeWeaver(method, weavingSettings);
			MethodDefintionWeaver = new SetPropertySignatureWeaver(weavingSettings.TypeDefinition);
		}
    }
}
