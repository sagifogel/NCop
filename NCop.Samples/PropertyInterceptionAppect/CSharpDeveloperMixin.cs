using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Samples.PropertyInterceptionAppect
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public string Code { get; set; }
    }
}
