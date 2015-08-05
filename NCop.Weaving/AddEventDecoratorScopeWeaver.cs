using System.Reflection;

namespace NCop.Weaving
{
    public class AddEventDecoratorScopeWeaver : AbstractAddRemoveEventMethodScopeWeaver
    {
        public AddEventDecoratorScopeWeaver(MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
        }
    }
}

