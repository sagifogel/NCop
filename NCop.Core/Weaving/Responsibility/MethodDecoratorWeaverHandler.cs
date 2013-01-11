﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public class MethodDecoratorWeaverHandler : AbstractMethodWeaverHandler
    {
        public MethodDecoratorWeaverHandler(Type type, ITypeDefinition typeDefinition)
            : base(type, typeDefinition) {
        }

        public override bool CanHandle {
            get {
                return true;
            }
        }

        protected override IMethodWeaver HandleInternal(MethodInfo methodInfo) {
            return new MethodDecoratorWeaver(methodInfo, Type, TypeDefinition);
        }
    }
}
