using HelloMvvm.OverviewModule.Repositories;
using Prism.Mvvm;
using Prism.Regions;

namespace HelloMvvm.OverviewModule.ViewModels
{
    public class EmployeeOverviewViewModel : BindableBase, INavigationAware
    {
        private string _firstname;
        private string _lastname;
        private readonly IStorageRepository _storageRepository;

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

            _storageRepository.AddItem($"{Firstname} {Lastname}");
        }

        public EmployeeOverviewViewModel(IStorageRepository storageRepository)
        {
            this._storageRepository = storageRepository;
        }
    }
}
