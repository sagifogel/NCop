using NCop.Aspects.Weaving.Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving
{
    public class TypeWeaverBuilderVisitor : AbstractTypeWeaverBuilderVisitor
    {
        private IMethodWeaverHandler _methodHandler = null;

        public TypeWeaverBuilderVisitor(Type type)
            : base(type) {
            _methodHandler = new AspectPipelineMethodWeaver(type);
        }

        public override void Visit(Type type) {
            var typeDefinitionWeaver = new MixinTypeDefinitionWeaver(null);

            TypeDefinition = typeDefinitionWeaver.Weave();
            _methodHandler = new AspectPipelineMethodWeaver(type);
            Builder.AddMixinTypeMap(null);
        }

        public override void Visit(MethodInfo method) {
            var methodWeaver = _methodHandler.Handle(method, TypeDefinition);

            Builder.AddMethodWeaver(methodWeaver);
        }

        protected override ITypeWeaverBuilder GetTypeWeaverBuilder(Type type) {
            return new MixinTypeWeaverBuilder(Type);
        }
    }
}
