using NCop.Core.Weaving;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static Attribute GetCustomAttribute(this ICustomAttributeProvider type, ISet<Type> attributesToMatch, bool inherit = true) {
            return type.GetCustomAttributes(inherit)
                       .FirstOrDefault(attr => attributesToMatch.Contains(attr)) as Attribute;
        }

        public static string GetAssemblyPublicKeyToken(this Type type) {
            return type.Assembly.GetPublicKeyToken();
        }

        public static string GetPublicKeyToken(this Assembly assembly) {
            return _publicKeyTokenValue.Match(assembly.FullName).Groups["PublicKeyTokenValue"].Value;
        }

        public static bool HasSamePublicKeyToken(this Assembly assembly, string token) {
            return assembly.GetPublicKeyToken().Equals(token);
        }

        public static bool HasSamePublicKeyToken(this Assembly assembly, params string[] tokens) {
            return tokens.Any(token => assembly.HasSamePublicKeyToken(token));
        }

        public static bool IsNCopAssembly(this Assembly assembly) {
            return assembly.GetPublicKeyToken().Equals(NCopToken);
        }

        public static bool InNCopAssembly(this Type type) {
            return type.Assembly.IsNCopAssembly();
        }

        public static bool IsDefined<TAttribute>(this Type type, bool inherit = true) where TAttribute : Attribute {
            return type.IsDefined(typeof(TAttribute), inherit);
        }

        public static bool IsDefined<TAttribute>(this MethodInfo method, bool inherit = true) where TAttribute : Attribute {
            return method.IsDefined(typeof(TAttribute), inherit);
        }

        public static bool IsDefined<TAttribute>(this PropertyInfo property, bool inherit = true) where TAttribute : Attribute {
            return property.IsDefined(typeof(TAttribute), inherit);
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

        public static MethodInfo[] GetOverridenMethods(this Type type) {
            return type.GetMethods()
                       .Where(method => method.IsOverride(type))
                       .ToArray();
        }

        public static bool IsOverride(this MethodInfo methodInfo, Type declaringType) {
            return methodInfo.DeclaringType == declaringType;
        }

        public static TypeBuilder SetCustomAttribute<TAttribute>(this TypeBuilder builder) where TAttribute : Attribute {
            var ctor = typeof(TAttribute).GetConstructor(Type.EmptyTypes);

            builder.SetCustomAttribute(new CustomAttributeBuilder(ctor, Type.EmptyTypes));

            return builder;
        }

        public static MethodBuilder DefineMethod(this TypeBuilder typeBuilder, MethodInfo methodInfo, MethodAttributes? attributes = null) {
            var parametrTypes = methodInfo.GetParameters()
                                          .Select(parameter => parameter.ParameterType);

            attributes = attributes ?? methodInfo.Attributes & ~MethodAttributes.Abstract;

            return typeBuilder.DefineMethod(methodInfo.Name, attributes.Value, methodInfo.ReturnType, parametrTypes.ToArray());
        }

        public static TypeBuilder DefineType(this Type parentType, string name = null, IEnumerable<Type> interfaces = null, TypeAttributes? attributes = null) {
            name = name ?? parentType.ToUniqueName();
            attributes = attributes ?? parentType.Attributes;

            return NCopModuleBuilder.Instance
                                    .DefineType(name, attributes.Value, parentType, interfaces.ToArray())
                                    .SetCustomAttribute<CompilerGeneratedAttribute>()
                                    .SetCustomAttribute<DebuggerNonUserCodeAttribute>();
        }

        public static string ToUniqueName(this Type type) {
            return string.Format("<NCop>.{0}", type.FullName);
        }

        public static FieldBuilder DefineField(this TypeBuilder typeBuilder, Type fieldType, FieldAttributes? attributes = null) {
            string name = fieldType.Name.ToUnderscoreFieldName();

            attributes = attributes ?? FieldAttributes.Private;

            return typeBuilder.DefineField(name, fieldType, attributes.Value);
        }
    }
}