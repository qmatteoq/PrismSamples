using HelloMvvm.OverviewModule.Repositories;
using HelloMvvm.OverviewModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMvvm.OverviewModule
{
    [Module(ModuleName ="OverviewModule")]
    public class OverviewModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(EmployeeOverviewView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IStorageRepository, StorageRepository>();
            containerRegistry.RegisterForNavigation<EmployeeOverviewView>("EmployeeOverviewView");
        }
    }
}
