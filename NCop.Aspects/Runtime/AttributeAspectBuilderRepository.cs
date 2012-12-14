using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Runtime
{
	public class AttributeAspectBuilderRepository : AspectBuilderRepository
    {   
        private Type[] _types = null;

		public AttributeAspectBuilderRepository(Type[] types)
		{
            _types = types;
        }
    }
}
