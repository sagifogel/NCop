using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving
{
    public class TypeWeaverBuilderVisitor : ITypeWeaverBuilderVisitor
    {
        public TypeWeaverBuilderVisitor(ITypeWeaverBuilder typeBuilder) {
            TypeBuilder = typeBuilder;
        }

        public ITypeWeaverBuilder TypeBuilder { get; private set; }

        public void Visit(Type type) {
            
        }

        public void Visit(MethodInfo method) {
        }

        public void Visit(PropertyInfo property) {
        }   

        private void Visit(MemberInfo memeberInfo, ITypeWeaverBuilder builder) { }
    }
}
