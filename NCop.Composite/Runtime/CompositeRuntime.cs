﻿using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Runtime;
using NCop.Core.Runtime;
using NCop.Composite.Engine;

namespace NCop.Composite.Runtime
{
    public class CompositeRuntime : IRuntime
    {
        private AspectsRuntime _aspectsRuntime = null;
        
        public CompositeRuntimeSettings Settings { get; set; }

        public void Run() {
            IEnumerable<CompositeMetadata> composites = null;
            Settings = Settings ?? new CompositeRuntimeSettings();

            _aspectsRuntime = new AspectsRuntime {
                Settings = new AspectsRuntimeSettings() {
                }
            };

            composites = CompositeMetadataMapper.Map(Settings.Assemblies).ToList();
            _aspectsRuntime.Run();
        }
    }
}
