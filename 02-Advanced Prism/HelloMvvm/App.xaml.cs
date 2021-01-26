using HelloMvvm.Repositories;
using HelloMvvm.ViewModels;
using HelloMvvm.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace HelloMvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public static IContainerRegistry ContainerRegistry { get; private set; }

        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IEmployeeRepository, EmployeeRepository>();
            containerRegistry.RegisterSingleton<EmployeeEditorViewModel>();
            containerRegistry.RegisterForNavigation<EmployeeEditorView>("EmployeeEditorView");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<OverviewModule.OverviewModule>(InitializationMode.WhenAvailable);
        }


        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @".\\Modules" };
        //}

    }
}
