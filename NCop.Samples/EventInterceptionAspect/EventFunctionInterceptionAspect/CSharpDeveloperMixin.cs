using System;

namespace NCop.Samples.EventInterceptionAspect.EventFunctionInterceptionAspect
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
