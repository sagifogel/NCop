using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractTypeVisitor<T> : ITypesVisitor<T>
    {
        private static readonly IEnumerable<T> _empty = Enumerable.Empty<T>();

        public virtual IEnumerable<T> Visit(Type type) {
            return Visit(type.GetFields(ReflectionUtils.AllFlags))
                     .Concat(Visit(type.GetMethods(ReflectionUtils.AllFlags)))
                        .Concat(Visit(type.GetProperties(ReflectionUtils.AllFlags)))
                            .Concat(Visit(type.GetConstructors(ReflectionUtils.AllFlags)));
        }

        public virtual IEnumerable<T> Visit(FieldInfo[] fields) {
            return _empty;
        }

        public virtual IEnumerable<T> Visit(MethodInfo[] methods) {
            return _empty;
        }

        public virtual IEnumerable<T> Visit(ConstructorInfo[] ctors) {
            return _empty;
        }

        public virtual IEnumerable<T> Visit(PropertyInfo[] properties) {
            return _empty;
        }
    }
}
