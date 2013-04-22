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

        public static Func<TResult> Curry<TResult, TArg1, TArg2>(Func<TArg1, TArg2, TResult> func, TArg1 arg1, TArg2 arg2) {
            return () => func(arg1, arg2);
        }

        public static Func<TResult> Curry<TResult, TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3) {
            return () => func(arg1, arg2, arg3);
        }

        public static Func<TResult> Curry<TResult, TArg1, TArg2, TArg3, TArg4>(Func<TArg1, TArg2, TArg3, TArg4, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) {
            return () => func(arg1, arg2, arg3, arg4);
        }
    }
}
