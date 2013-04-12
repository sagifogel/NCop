using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Weaving;
using System.Reflection.Emit;
using NCop.Mixins.Engine;
using NCop.Core.Extensions;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinition : ITypeDefinition
    {
        private readonly IMixinsMap _mixinsMap = null;
        private readonly Dictionary<Type, MixinTypeDefinition> _mixinTypeDefinition = null;

        public MixinsTypeDefinition(Type mixinsType, IMixinsMap mixinsMap) {
            Type = mixinsType;
            _mixinsMap = mixinsMap;
            _mixinTypeDefinition = new Dictionary<Type, MixinTypeDefinition>();
            CreateTypeBuilder();
            CreateMixinTypeDefinitions();
        }

        public Type Type { get; private set; }

        public TypeBuilder TypeBuilder { get; private set; }

        public FieldBuilder GetOrAddFieldBuilder(Type type) {
            MixinTypeDefinition mixinTypeDefinition;

            if (_mixinTypeDefinition.TryGetValue(type, out mixinTypeDefinition)) {
                return mixinTypeDefinition.GetOrAddFieldBuilder(type);
            }

            return null;
        }

        private void CreateTypeBuilder() {
            var interfaces = _mixinsMap.Select(mixin => mixin.Contract);

            TypeBuilder = typeof(object).DefineType(name: Type.ToUniqueName(), interfaces: interfaces);
        }

        private void CreateMixinTypeDefinitions() {
            _mixinsMap.ForEach(mixin => {
                var mixinTypeDefinition = new MixinTypeDefinition(mixin.Contract, TypeBuilder);

                _mixinTypeDefinition.Add(mixin.Contract, mixinTypeDefinition);
            });
        }
    }
}
