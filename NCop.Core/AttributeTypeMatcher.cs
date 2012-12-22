using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Core
{
    public class AttributeTypeMatcher<TAttribute> : IEnumerable<Tuple<Type, Type>>
        where TAttribute : Attribute
    {
        private ISet<Type> _immediateInterfaces = null;
        private ISet<Type> _registered = new HashSet<Type>();
        private Func<TAttribute, Type[]> _typeFactory = null;
        private List<Tuple<Type, Type>> _map = new List<Tuple<Type, Type>>();

        public AttributeTypeMatcher(Type type, Func<TAttribute, Type[]> typeFactory) {
            _typeFactory = typeFactory;
            _immediateInterfaces = type.GetImmediateInterfaces().ToSet();
            _map.AddRange(FindTypesRecursively(type));

            if (_map.Count != _immediateInterfaces.Count) {
                var missing = _immediateInterfaces.Except(_map.Select(map => map.Item1));

                throw new MissingTypeException(missing.First().Name);
            }
        }

        private IEnumerable<Tuple<Type, Type>> FindTypesRecursively(Type type) {
            var types = FindTypes(type);

            if (_immediateInterfaces.Count != _registered.Count) {
                var interfaces = type.GetImmediateInterfaces();
                var leftToFind = interfaces.Except(_registered);

                types = types.Concat(leftToFind.SelectMany(@interface => {
                    return FindTypesRecursively(@interface);
                }));
            }

            return types;
        }

        private IEnumerable<Tuple<Type, Type>> FindTypes(Type type) {
            var typeMap = new List<Tuple<Type, Type>>();
            var attribute = type.GetCustomAttribute<TAttribute>();

            if (attribute != null) {
                _typeFactory(attribute).ForEach(t => {
                    t.GetImmediateInterfaces()
                         .ForEach(@interface => {
                             if (_immediateInterfaces.Contains(@interface)) {
                                 var tuple = Tuple.Create(@interface, t);

                                 if (!_registered.Add(@interface)) {
                                     throw new DuplicateTypeAnnotationException(@interface.FullName);
                                 }

                                 typeMap.Add(tuple);
                             }
                         });
                });
            }

            return typeMap.NullCoalesce();
        }

        public int Count {
            get {
                return _map.Count;
            }
        }

        public IEnumerator<Tuple<Type, Type>> GetEnumerator() {
            return _map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
