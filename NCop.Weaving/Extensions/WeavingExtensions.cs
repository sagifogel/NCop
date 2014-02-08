using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Weaving.Extensions
{
    public static class WeavingExtensions
    {
        public static IMethodScopeWeaver ToMethodScopeWeaver(this Action<ILGenerator> weaverAction) {
            return new DelegateMethodScopeWeaver(weaverAction);
        }
    }
}
