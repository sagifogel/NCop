using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal interface IBindingWeaver : IWeaver
    {
        FieldInfo Weave();
    }
}
