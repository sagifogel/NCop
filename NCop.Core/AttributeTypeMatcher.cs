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
        private ISet<Type> interfaces = null;
        private ISet<Type> registered = new HashSet<Type>();
        private Func<TAttribute, Type[]> typeFactory = null;
        private List<Tuple<Type, Type>> map = new List<Tuple<Type, Type>>();

        public AttributeTypeMatcher(Type type, Func<TAttribute, Type[]> typeFactory) {
            this.typeFactory = typeFactory;
            interfaces = type.GetInterfaces().ToSet();
            map.AddRange(FindTypesRecursively(type));

            if (map.Count != GetMapCount(interfaces.Concat(type))) {
                var missing = interfaces.Except(map.Select(m => m.Item1));

                throw new MissingTypeException(missing.First().Name);
            }
        }

        private int GetMapCount(IEnumerable<Type> interfaces) {
            var attributes = interfaces.SelectMany(@interface => {
                var attrs = @interface.GetCustomAttributesArray<TAttribute>();

                return attrs.SelectMany(attr => {
                    return typeFactory(attr);
                });
            });

            return new HashSet<Type>(attributes).Count;
        }

        private IEnumerable<Tuple<Type, Type>> FindTypesRecursively(Type type) {
            var types = FindTypes(type);

            if (interfaces.Count != registered.Count) {
                var immediateInterfaces = type.GetImmediateInterfaces();
                var leftToFind = immediateInterfaces.Except(registered);

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
                typeFactory(attribute).ForEach(t => {
                    t.GetImmediateInterfaces()
                     .ForEach(@interface => {
                         if (interfaces.Contains(@interface)) {
                             var tuple = Tuple.Create(@interface, t);

                             if (!registered.Add(@interface)) {
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
                return map.Count;
            }
        }

        public IEnumerator<Tuple<Type, Type>> GetEnumerator() {
            return map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
