using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;

namespace NCop.Core.Extensions
{
    public static class ReflectionUtils
    {
        internal static readonly string NCopToken = "5f8f9ac08842d356";
        private static readonly Regex _publicKeyTokenValue = new Regex(@"PublicKeyToken=(?<PublicKeyTokenValue>[A-Fa-f0-9]{16})");

#if !NET_4_5

        public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this ICustomAttributeProvider type, bool inherit = true) {
            return type.GetCustomAttributes(typeof(TAttribute), inherit)
                       .Cast<TAttribute>();
        }

        public static TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider type, bool inherit = true) {
            return type.GetCustomAttributes<TAttribute>(inherit).FirstOrDefault();
        }

#endif

        public static string MatchPublicKeyToken(this Assembly assembly) {
            return _publicKeyTokenValue.Match(assembly.FullName).Groups["PublicKeyTokenValue"].Value;
        }

        public static bool HasSamePublicKeyToken(this Assembly assembly, string token) {
            return assembly.MatchPublicKeyToken().Equals(token);
        }

        public static bool IsNCopAssembly(this Assembly assembly) {
            return assembly.MatchPublicKeyToken().Equals(NCopToken);
        }

        public static bool InNCopAssembly(this Type type) {
            return type.Assembly.IsNCopAssembly();
        }

        public static bool IsDefined<TAttribute>(this Type type, bool inherit = true) where TAttribute : Attribute {
            return type.IsDefined(typeof(TAttribute), inherit);
        }

        public static bool IsNCopDefined<TAttribute>(this Type type, bool inherit = true) where TAttribute : Attribute {
            return type.IsDefined(typeof(TAttribute), inherit) &&
                    type.GetCustomAttribute<TAttribute>(true)
                        .GetType()
                        .InNCopAssembly();
        }

        public static IEnumerable<Type> GetImmediateInterfaces(this Type type) {
            var interfaces = type.GetInterfaces();
            var nonInheritedInterfaces = new HashSet<Type>(interfaces);

            foreach (var @interface in interfaces) {
                @interface.RemoveInheritedInterfaces(nonInheritedInterfaces);
            }

            return nonInheritedInterfaces;
        }

        private static void RemoveInheritedInterfaces(this Type type, HashSet<Type> interfaces) {
            foreach (var @interface in type.GetInterfaces()) {
                interfaces.Remove(@interface);
                RemoveInheritedInterfaces(@interface, interfaces);
            }
        }
    }
}