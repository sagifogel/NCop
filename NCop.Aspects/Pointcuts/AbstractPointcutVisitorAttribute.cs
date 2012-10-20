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
    public abstract class AbstractPointcutVisitorAttribute : AspectAttribute, IPointcutVisitor, IPointcutProvider
    {
        private IEnumerable<IPointcut> Visit(Type type) {
            return Visit(type.GetFields(ReflectionUtils.AllFlags))
                     .Concat(Visit(type.GetMethods(ReflectionUtils.AllFlags)))
                        .Concat(Visit(type.GetProperties(ReflectionUtils.AllFlags)))
                            .Concat(Visit(type.GetConstructors(ReflectionUtils.AllFlags)));
        }

        public virtual IEnumerable<IPointcut> Visit(FieldInfo[] fields) {
            return null;
        }

        public virtual IEnumerable<IPointcut> Visit(MethodInfo[] methods) {
            return null;
        }

        public virtual IEnumerable<IPointcut> Visit(ConstructorInfo[] ctors) {
            return null;
        }

        public virtual IEnumerable<IPointcut> Visit(PropertyInfo[] properties) {
            return null;
        }

        public PointcutCollection Match(Type type) {
            var pointcuts = Visit(type);

            return new PointcutCollection(pointcuts);
        }
    }
}
