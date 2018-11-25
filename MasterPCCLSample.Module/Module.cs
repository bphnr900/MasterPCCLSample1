using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MasterPCCLSample.Module.Views;
using Prism.Modularity;
using Prism.Regions;

namespace MasterPCCLSample.Module
{
    public class Module : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            this.Container.RegisterType<object, CompareResultView>(nameof(CompareResultView));

            this.RegionManager.RequestNavigate("MainRegion", nameof(CompareResultView));
        }
    }
}
