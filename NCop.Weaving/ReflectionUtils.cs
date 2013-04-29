using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.ComponentModel;

namespace NCop.Weaving
{
    public static class ReflectionUtils
    {   
        internal static MethodBuilder DefineMethod(this TypeBuilder typeBuilder, MethodInfo methodInfo, MethodAttributes? attributes = null) {
            var parametrTypes = methodInfo.GetParameters()
                                          .Select(parameter => parameter.ParameterType);

            attributes = attributes ?? methodInfo.Attributes & ~MethodAttributes.Abstract;

            return typeBuilder.DefineMethod(methodInfo.Name, attributes.Value, methodInfo.ReturnType, parametrTypes.ToArray());
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TypeBuilder DefineType(this Type parentType, string name = null, IEnumerable<Type> interfaces = null, TypeAttributes? attributes = null) {
            name = name ?? parentType.ToUniqueName();
            attributes = attributes ?? parentType.Attributes;

            return NCopModuleBuilder.Instance
                                    .DefineType(name, attributes.Value, parentType, interfaces.ToArray())
                                    .SetCustomAttribute<CompilerGeneratedAttribute>()
                                    .SetCustomAttribute<DebuggerNonUserCodeAttribute>();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string ToUniqueName(this Type type) {
            return string.Format("<NCop>.{0}", type.FullName);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FieldBuilder DefineField(this TypeBuilder typeBuilder, Type fieldType, FieldAttributes? attributes = null) {
            string name = fieldType.Name.ToUnderscoreFieldName();

            attributes = attributes ?? FieldAttributes.Private;

            return typeBuilder.DefineField(name, fieldType, attributes.Value);
        }
    }
}
