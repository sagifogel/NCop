using System;

namespace NCop.Samples.MultipleAspects.Events
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
