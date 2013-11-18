using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Aspects.Engine
{
    internal static class AdviceArgsConverter
    {
        private readonly static ConcurrentDictionary<string, Delegate> converters = null;

        static AdviceArgsConverter() {
            converters = new ConcurrentDictionary<string, Delegate>();
        }

        internal static TOutAdviceArgs ConvertTo<TInAdviceArgs, TOutAdviceArgs>(TInAdviceArgs adviceArgs)
            where TInAdviceArgs : AdviceArgs
            where TOutAdviceArgs : AdviceArgs {

            var inAdviceArgs = typeof(TInAdviceArgs);
            var outAdviceArgs = typeof(TOutAdviceArgs);
            var key = "{0}->{1}".Fmt(inAdviceArgs.AssemblyQualifiedName, outAdviceArgs.AssemblyQualifiedName);

            var factory = (Func<TInAdviceArgs, TOutAdviceArgs>)converters.GetOrAdd(key, (k) => {
                Expression<Func<TInAdviceArgs, TOutAdviceArgs>> lambda = null;

                lock (converters) {
                    var ctor = inAdviceArgs.GetConstructors().First();

                    outAdviceArgs.GetProperties();

                    lambda = Expression.Lambda<Func<TInAdviceArgs, TOutAdviceArgs>>(
                               Expression.New(ctor, null),
                                    null);
                }

                return lambda.Compile();
            });

            return factory(adviceArgs);
        }
    }
}
