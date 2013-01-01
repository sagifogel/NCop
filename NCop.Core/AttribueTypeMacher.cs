using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Core
{
    public class AttribueTypeMacher
    {
        private Tuple<Type, Type> _map = null;
        private ISet<Type> _immediateInterfaces = null;
        private ISet<Type> _registered = new HashSet<Type>();

        public AttribueTypeMacher(Type[] types, Type[] attributesToMatch) {
            var attributesSet = attributesToMatch.ToSet();
            var tuple = types.SelectFirst(type => type.GetCustomAttribute(attributesSet), attr => attr != null);

            if (tuple == null) {
                throw new AttributeNotFoundException("Could not found matching attribute");
            }

            Map = Tuple.Create(tuple.Item1, tuple.Item2.GetType());
        }

        public Tuple<Type,Type> Map { get; private set; }
    }
}

