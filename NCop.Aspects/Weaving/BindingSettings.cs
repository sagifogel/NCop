using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class BindingSettings
    {
        public bool IsFunction { get; set; }
        public Type BindingType { get; set; }
        public IMethodLocalWeaver ArgumentsWeaver { get; set; }
    }
}
