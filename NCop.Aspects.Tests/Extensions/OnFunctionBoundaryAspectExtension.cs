using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests.Extensions
{
    public static class OnFunctionBoundaryAspectExtension
    {
        internal static string Stringify(this IEnumerable<AspectJoinPoints> source) {
            return string.Join(":", source);
        }
        
        internal static void AddToReturnValue<T>(this FunctionExecutionArgs<T, string> args, AspectJoinPoints joinPoint) {
            string format = "{0}:{1}";

            if (args.ReturnValue.IsNullOrEmpty()) {
                args.ReturnValue = joinPoint.ToString();
                return;
            }

            args.ReturnValue = format.Fmt(args.ReturnValue, joinPoint.ToString());
        }

        internal static void AddToReturnValue<T>(this FunctionInterceptionArgs<T, string> args, AspectJoinPoints joinPoint) {
            string format = "{0}:{1}";

            if (args.ReturnValue.IsNullOrEmpty()) {
                args.ReturnValue = joinPoint.ToString();
                return;
            }

            args.ReturnValue = format.Fmt(args.ReturnValue, joinPoint.ToString());
        }
    }
}
