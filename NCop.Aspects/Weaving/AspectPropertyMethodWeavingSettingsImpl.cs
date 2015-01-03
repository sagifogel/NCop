using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    public class AspectPropertyMethodWeavingSettingsImpl : AspectWeavingSettingsImpl, IAspectWeavingSettings
    {
        public PropertyInfo PropertyInfoContract { get; set; }
    }
}
