using HelloMvvm.Dialogs;
using HelloMvvm.Messages;
using HelloMvvm.Repositories;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace HelloMvvm.ViewModels
{
    public class EmployeeEditorViewModel : BindableBase, INotifyDataErrorInfo
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;
        private string _firstname;
        private string _lastname;
        private bool _isBusy;

        public EmployeeEditorViewModel(IEmployeeRepository employeeRepository, 
            IRegionManager regionManager, IEventAggregator eventAggregator, IDialogService dialogService)
        {
            _employeeRepository = employeeRepository;
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;
            this._dialogService = dialogService;
        }


        private async void OnAdd()
        {
            try
            {
                string caption = "Do you want to continue?";
                DialogParameters dialogParameters = new DialogParameters();
                dialogParameters.Add("Caption", caption);

                var result = await _dialogService.ShowDialogAsync("OkDialog", dialogParameters);
                string message = result.Parameters.GetValue<string>("Message");
                if (result.Result == ButtonResult.Yes)
                {
                    IsBusy = true;
                    _eventAggregator.GetEvent<StartAnimationMessage>().Publish();

                    await _employeeRepository.Add(Firstname, Lastname);

                    NavigationParameters parameters = new NavigationParameters();
                    parameters.Add("FirstName", Firstname);
                    parameters.Add("LastName", Lastname);
                    parameters.Add("Message", message);

                    _regionManager.RequestNavigate("MainRegion", "EmployeeOverviewView", parameters);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    SetProperty(ref _isBusy, value);
                }
            }
        }

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                if (_firstname != value)
                {
                    SetProperty(ref _firstname, value);
                    OnErrorsChanged(nameof(Firstname));
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
                    OnErrorsChanged(nameof(Lastname));
                }
            }
        }

        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new DelegateCommand(OnAdd, () => !HasErrors && !IsBusy)
                                      .ObservesProperty(() => Firstname)
                                      .ObservesProperty(() => Lastname)
                                      .ObservesProperty(() => IsBusy);
                }

                return _addCommand;
            }
        }


        #region INotifyDataErrorInfo
        public IEnumerable GetErrors(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Lastname):
                    if (string.IsNullOrWhiteSpace(Lastname))
                    {
                        return new string[] { "Lastname required." };
                    }
                    break;
                case nameof(Firstname):
                    if (string.IsNullOrWhiteSpace(Firstname))
                    {
                        return new string[] { "Firstname required." };
                    }
                    break;
                default:
                    break;
            }

            return Enumerable.Empty<string>();
        }

        public bool HasErrors
            => GetErrors(nameof(Lastname)).Cast<object>().Any()
            || GetErrors(nameof(Firstname)).Cast<object>().Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

    }
}
