﻿using NCop.Core.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
    public interface ITypeWeaverBuilderVisitor
    {
        ITypeWeaverBuilder Visit();
    }
}
