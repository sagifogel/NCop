using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using NCop.Core.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            ISet<Type> mappedInterfaces = null;

            this.typeFactory = typeFactory;
            interfaces = type.GetInterfacesAndSelf().ToSet();
            map.AddRange(FindTypesRecursively(type));
            mappedInterfaces = GetMappedInterfaces(interfaces.Concat(type));

            if (map.Count != mappedInterfaces.Count) {
                var missing = mappedInterfaces.Except(map.Select(m => m.Item1));

                throw new MissingTypeException(missing.First().Name);
            }
        }

        private ISet<Type> GetMappedInterfaces(IEnumerable<Type> interfaces) {
            var attributes = interfaces.Where(@interface => {
                return !@interface.GetImmediateInterfaces()
                                  .Any();
            });

            return new HashSet<Type>(attributes);
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
                typeFactory(attribute).ForEach(implementationType => {
                    if (implementationType.IsAbstract) {
                        var message = Resources.AbstracClassAnnotationIsNotSupported.Fmt(implementationType);

                        throw new TypeDefinitionInitializationException(message);
                    }

                    implementationType.GetImmediateInterfaces()
                                      .ForEach(@interface => {
                                          if (interfaces.Contains(@interface) || interfaces.HasCovariantType(@interface)) {
                                              var tuple = Tuple.Create(@interface, implementationType);

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
