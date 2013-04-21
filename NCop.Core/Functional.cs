using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core
{
    public static class Functional
    {
        public static Func<TResult> Curry<TResult, TArg>(Func<TArg, TResult> func, TArg arg) {
            return () => func(arg);
        }
    }
}
