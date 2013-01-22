using NCop.Core.Extensions;
using NCop.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public abstract class EnumerableProjectionTypeVisitor<T> : IEnumerableProjectionTypeVisitor<T>
    {
        protected static readonly IEnumerable<T> Empty = Enumerable.Empty<T>();

        public virtual IEnumerable<T> Visit(Type type) {
            return Visit(type.GetMethods())
                     .SelfJoin(Visit(type.GetProperties()));
        }

        public virtual IEnumerable<T> Visit(MethodInfo[] methods) {
            return Empty;
        }

        public virtual IEnumerable<T> Visit(PropertyInfo[] properties) {
            return Empty;
        }
    }
}
