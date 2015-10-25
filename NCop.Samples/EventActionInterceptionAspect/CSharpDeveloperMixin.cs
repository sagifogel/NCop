using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Samples.EventActionInterceptionAspect
{
    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Action<string> OnCodeCompleted;

        public void Code(string code) {
            var onCodeCompleted = OnCodeCompleted;

            if (onCodeCompleted != null) {
                onCodeCompleted(code);
            }
        }
    }
}
