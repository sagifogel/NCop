using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Samples.EventFunctionInterceptionAspect
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Func<string> OnCodeCompleted;

        public string Code() {
            var onCodeCompleted = OnCodeCompleted;

            if (onCodeCompleted != null) {
                return onCodeCompleted();
            }

            return string.Empty;
        }
    }
}
