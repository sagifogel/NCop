using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Weaving
{
	public interface IPropertyWeavingSettings : IWeavingSettings
	{
		PropertyInfo PropertyInfoImpl { get; }
	}
}
