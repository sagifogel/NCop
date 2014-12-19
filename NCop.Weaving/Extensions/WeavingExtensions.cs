using System;
using System.Reflection.Emit;

namespace NCop.Weaving.Extensions
{
    public static class WeavingExtensions
    {
        public static IMethodScopeWeaver ToMethodScopeWeaver(this Action<ILGenerator> weaverAction) {
            return new DelegateMethodScopeWeaver(weaverAction);
        }
    }
}
