using NCop.Aspects.Weaving.Responsibility;
using NCop.Core.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class AspectTypeWeaverBuilderVisitor : AbstractTypeWeaverBuilderVisitor
    {
        private IMethodWeaverHandler _methodHandler = null;

        public AspectTypeWeaverBuilderVisitor(Type type)
            : base(type) {
            _methodHandler = new AspectPipelineMethodWeaver(type);
            Builder = new MixinTypeWeaverBuilder(Type);
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
    }
}
