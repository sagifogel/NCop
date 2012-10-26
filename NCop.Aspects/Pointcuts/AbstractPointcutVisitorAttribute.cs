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
    public class AbstractPointcutAttribute : PointcutAttribute, IPointcutVisitor
    {
        private static readonly IEnumerable<IPointcut> _empty = Enumerable.Empty<IPointcut>();

        public IEnumerable<IPointcut> Visit(Type type) {
            return Visit(type.GetFields(ReflectionUtils.AllFlags))
                     .Concat(Visit(type.GetMethods(ReflectionUtils.AllFlags)))
                        .Concat(Visit(type.GetProperties(ReflectionUtils.AllFlags)))
                            .Concat(Visit(type.GetConstructors(ReflectionUtils.AllFlags)));
        }

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
    }
}
