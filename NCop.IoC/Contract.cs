using System;
using System.Reflection;

namespace NCop.IoC
{
    public static class Contract
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
                throw exceptionFactory();
            }
        }

        public static void RequiersConstructorNotNull<TException>(ConstructorInfo ctor, Func<TException> exceptionFactory) where TException : Exception {
            if (ReferenceEquals(null, ctor)) {
                throw exceptionFactory();
            }
        }

        public static void Throw<TException>(Func<TException> exceptionFactory) where TException : Exception {
            throw exceptionFactory();
        }
    }
}
