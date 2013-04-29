using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Weaving;
using System.Reflection.Emit;
using NCop.Mixins.Engine;
using NCop.Core.Extensions;

namespace NCop.Mixins.Weaving
{
    internal class MixinsTypeDefinition : ITypeDefinition
    {
        private readonly IMixinsMap mixinsMap = null;
        private readonly Dictionary<Type, MixinTypeDefinition> mixinTypeDefinitions = null;

        internal MixinsTypeDefinition(Type mixinsType, IMixinsMap mixinsMap) {
            Type = mixinsType;
            this.mixinsMap = mixinsMap;
            mixinTypeDefinitions = new Dictionary<Type, MixinTypeDefinition>();
            CreateTypeBuilder();
            CreateMixinTypeDefinitions();
        }

        public Type Type { get; private set; }

        public TypeBuilder TypeBuilder { get; private set; }

        public FieldBuilder GetOrAddFieldBuilder(Type type) {
            MixinTypeDefinition mixinTypeDefinition;

            if (mixinTypeDefinitions.TryGetValue(type, out mixinTypeDefinition)) {
                return mixinTypeDefinition.GetOrAddFieldBuilder(type);
            }

            return null;
        }

        private void CreateTypeBuilder() {
            var interfaces = mixinsMap.Select(mixin => mixin.Contract);

            TypeBuilder = typeof(object).DefineType(name: Type.ToUniqueName(), interfaces: interfaces);
        }

        private void CreateMixinTypeDefinitions() {
            mixinsMap.ForEach(mixin => {
                var mixinTypeDefinition = new MixinTypeDefinition(mixin.Contract, TypeBuilder);

                mixinTypeDefinitions.Add(mixin.Contract, mixinTypeDefinition);
            });
        }
    }
}
