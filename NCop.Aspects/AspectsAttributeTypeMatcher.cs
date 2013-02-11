using NCop.Aspects.Framework;
using NCop.Core;
using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Aspects
{
    public class AspectsAttributeTypeMatcher : Tuples<Type, IEnumerable<Type>>
    {
        private ISet<Type> _immediateInterfaces = null;
        private ConcurrentDictionary<Type, List<Type>> _registered = null;

        public AspectsAttributeTypeMatcher(Type type) {
            _registered = new ConcurrentDictionary<Type, List<Type>>();
            _immediateInterfaces = type.GetImmediateInterfaces().ToSet();
            RegisterTypesRecursively(type);

            if (_registered.Count != _immediateInterfaces.Count) {
                var missing = _immediateInterfaces.Except(_registered.Keys);

                throw new MissingTypeException(missing.First().Name);
            }

            Value = _registered.Select(kv => Tuple.Create(kv.Key, kv.Value.AsEnumerable()));
        }

        private void RegisterTypesRecursively(Type type) {
            RegisterTypes(type);

            if (_immediateInterfaces.Count != _registered.Count) {
                var leftToFind = _immediateInterfaces.Except(_registered.Keys);

                leftToFind.ForEach(@interface => {
                    RegisterTypesRecursively(@interface);
                });
            }
        }

        private void RegisterTypes(Type type) {
            var attribute = type.GetCustomAttribute<AspectsAttribute>();
            Func<Type, List<Type>, List<Type>> updateValueFactory = null;

            if (attribute != null) {
                attribute.Aspects.ForEach(aspect => {
                    aspect.GetImmediateInterfaces()
                          .ForEach(@interface => {
                              if (_immediateInterfaces.Contains(@interface)) {
                                  var addValue = new List<Type> { aspect };

                                  updateValueFactory = (key, oldValue) => new List<Type>(oldValue.Concat(aspect));
                                  _registered.AddOrUpdate(@interface, addValue, updateValueFactory);
                              }
                          });
                });
            }
        }
    }
}
