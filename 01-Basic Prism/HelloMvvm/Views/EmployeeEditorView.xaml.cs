using HelloMvvm.Messages;
using HelloMvvm.ViewModels;
using Prism.Events;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Unity;

namespace HelloMvvm.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class EmployeeEditorView : UserControl
    {
        public EmployeeEditorView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            eventAggregator.GetEvent<StartAnimationMessage>().Subscribe( () =>
               {
                   Storyboard sb = this.FindResource("AddButtonAnimation") as Storyboard;
                   sb.Begin();
               }, ThreadOption.UIThread);

        }
    }
}
