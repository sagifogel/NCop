using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Pointcuts
{
    public class AbstractPointcutAttribute : PointcutAttribute, IPointcutVisitor, IPointcutProvider
    {
        private static readonly IEnumerable<IPointcut> _empty = Enumerable.Empty<IPointcut>();

        public IPointcutCollection Match(Type type) {
            var pointcuts = Visit(type);

            return new PointcutCollection(pointcuts);
        }

        public virtual IEnumerable<IPointcut> Visit(FieldInfo[] fields) {
            return _empty;
        }

        public virtual IEnumerable<IPointcut> Visit(MethodInfo[] methods) {
            return _empty;
        }

        public virtual IEnumerable<IPointcut> Visit(ConstructorInfo[] ctors) {
            return _empty;
        }

        public virtual IEnumerable<IPointcut> Visit(PropertyInfo[] properties) {
            return _empty;
        }

        public IEnumerable<IPointcut> Visit(Type type) {
            throw new NotImplementedException();
        }
    }
}
