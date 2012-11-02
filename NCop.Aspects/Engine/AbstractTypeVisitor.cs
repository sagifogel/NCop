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

        public virtual IEnumerable<T> Visit(Type type)
        {
            return Visit(type.GetFields(Flags))
                     .Concat(Visit(type.GetMethods(Flags)))
                        .Concat(Visit(type.GetProperties(Flags)))
                            .Concat(Visit(type.GetConstructors(Flags)));
        }


        public virtual BindingFlags Flags
        {
            get { return BindingFlags.Instance | BindingFlags.Public; }
        }

        public virtual IEnumerable<T> Visit(FieldInfo[] fields)
        {
            return _empty;
        }

        public virtual IEnumerable<T> Visit(MethodInfo[] methods)
        {
            return _empty;
        }

        public virtual IEnumerable<T> Visit(ConstructorInfo[] ctors)
        {
            return _empty;
        }

        public virtual IEnumerable<T> Visit(PropertyInfo[] properties)
        {
            return _empty;
        }
    }
}
