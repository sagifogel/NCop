using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class Contract
    {
        public static void RequiersNotInterface<TException>(Type type, Func<TException> exceptionFactory) where TException : Exception {
            if (type.IsInterface) {
                throw exceptionFactory();
            }
        }

        public static void RequiersNotNull<T, TException>(T value, Func<TException> exceptionFactory)
            where T : class
            where TException : Exception {
            if (ReferenceEquals(null, value)) {
                Throw(exceptionFactory);
            }
        }

        public static void Throw<TException>(Func<TException> exceptionFactory) where TException : Exception {
            throw exceptionFactory();
        }
    }
}
