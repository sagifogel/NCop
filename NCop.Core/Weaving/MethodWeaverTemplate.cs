using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MethodWeaverTemplate : IMethodWeaver, IWeaver
    {
        public MethodWeaverTemplate(MethodPipelineWeavers pipelineWeavers) {
            PipelineWeavers = pipelineWeavers;
        }

        public void DefineMethod() {
            throw new NotImplementedException();
        }

        public void WeaveMethodScope() {
            throw new NotImplementedException();
        }

        public void WeaveEndMethod() {
            throw new NotImplementedException();
        }

        public MethodPipelineWeavers PipelineWeavers { get; private set;}

        public void Weave() {
            throw new NotImplementedException();
        }
    }
}
