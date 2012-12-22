using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractTypeVisitor<T> : ITypeVisitor<T>
    {
        protected static readonly IEnumerable<T> Empty = Enumerable.Empty<T>();

        public virtual IEnumerable<T> Visit(Type type) {
            return Visit(type.GetMethods(Flags))
                     .SelfJoin(Visit(type.GetProperties(Flags)));
        }

        public virtual BindingFlags Flags {
            get {
                return BindingFlags.Instance | BindingFlags.Public;
            }
        }

        public virtual IEnumerable<T> Visit(MethodInfo[] methods) {
            return Empty;
        }

        public virtual IEnumerable<T> Visit(PropertyInfo[] properties) {
            return Empty;
        }
    }
}
