using NCop.Composite.Framework;
using System;

namespace NCop.Samples.DependableMixins
{
    [IgnoreRegistration]
    public class CSharpDeveloperMixin : IDeveloper
    {
        private readonly ICSharpLanguageVersion languageVersion = null;

        public CSharpDeveloperMixin(ICSharpLanguageVersion languageVersion) {
            this.languageVersion = languageVersion;
        }

        public void Code() {
            Console.WriteLine("C# {0} coding", languageVersion.Version);
        }
    }
}
