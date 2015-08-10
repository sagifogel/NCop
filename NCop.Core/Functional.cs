using System;

namespace NCop.Core
{
    public static class Functional
    {
        public static Func<TResult> Curry<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3) {
            return () => func(arg1, arg2, arg3);
        }
    }
}
