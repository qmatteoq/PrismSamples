using HelloMvvm.Repositories;
using Prism.Mvvm;
using Prism.Regions;

namespace HelloMvvm.ViewModels
{
    public class EmployeeOverviewViewModel : BindableBase, INavigationAware
    {
        private string _firstname;
        private string _lastname;
        private string _message;

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                if (_firstname != value)
                {
                    SetProperty(ref _firstname, value);
                }
            }
        }
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                if (_lastname != value)
                {
                    SetProperty(ref _lastname, value);
                }
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    SetProperty(ref _message, value);
                }
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Firstname = navigationContext.Parameters["FirstName"].ToString();
            Lastname = navigationContext.Parameters["LastName"].ToString();
            Message = navigationContext.Parameters["Message"].ToString();
        }

    }
}
