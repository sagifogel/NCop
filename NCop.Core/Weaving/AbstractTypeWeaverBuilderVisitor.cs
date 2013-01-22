using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Core.Weaving
{
    public abstract class AbstractTypeWeaverBuilderVisitor : ITypeWeaverBuilderVisitor
    {
        public AbstractTypeWeaverBuilderVisitor(Type type) {
            Type = type;
        }

        protected Type Type { get; private set; }

        protected ITypeWeaverBuilder Builder { get; set; }

        protected ITypeDefinition TypeDefinition { get; set; }

        public virtual void Visit(Type type) { }

        public virtual void Visit(MethodInfo methodInfo) { }

        public virtual void Visit(PropertyInfo propertyInfo) { }

        protected virtual void VisitChildren() {
            Visit(Type);
            Type.GetMethods().ForEach(method => Visit(method));
            Type.GetProperties().ForEach(property => Visit(property));
        }

        public virtual ITypeWeaverBuilder Visit() {
            VisitChildren();

            return Builder;
        }
    }
}
