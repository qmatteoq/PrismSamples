using HelloMvvm.Dialogs;
using HelloMvvm.Repositories;
using HelloMvvm.ViewModels;
using HelloMvvm.Views;
using Prism.Ioc;
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
            containerRegistry.RegisterForNavigation<EmployeeEditorView>("EmployeeEditorView");
            containerRegistry.RegisterForNavigation<EmployeeOverviewView>("EmployeeOverviewView");

            containerRegistry.RegisterDialog<OkDialog, OkDialogViewModel>();
        }

    }
}
