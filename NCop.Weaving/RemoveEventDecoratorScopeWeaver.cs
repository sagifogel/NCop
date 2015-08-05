using System.Reflection;

namespace NCop.Weaving
{
    public class RemoveEventDecoratorScopeWeaver : AbstractAddRemoveEventMethodScopeWeaver
    {
        public RemoveEventDecoratorScopeWeaver(MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
        }
    }
}
