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
    public abstract class AbstractPointcutMatcherAttribute : Attribute, IPointcutVisitor, IPointcutMatcher
    {   
        private IEnumerable<IPointcut> Visit(Type type) {
            yield return Visit(type.GetFields(ReflectionUtils.AllFlags));
            yield return Visit(type.GetMethods(ReflectionUtils.AllFlags));
            yield return Visit(type.GetProperties(ReflectionUtils.AllFlags));
            yield return Visit(type.GetConstructors(ReflectionUtils.AllFlags));
        }

        public virtual IPointcut Visit(FieldInfo[] fields) {
            return null;
        }

        public virtual IPointcut Visit(MethodInfo[] methods) {
            return null;
        }

        public virtual IPointcut Visit(ConstructorInfo[] ctors) {
            return null;
        }

        public virtual IPointcut Visit(PropertyInfo[] properties) {
            return null;
        }

        public PointcutMatchCollection Match(Type type) {
            var pointcuts = Visit(type);

            return new PointcutMatchCollection(pointcuts);
        }
    }
}
