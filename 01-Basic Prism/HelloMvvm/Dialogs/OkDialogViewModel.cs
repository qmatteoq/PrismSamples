using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMvvm.Dialogs
{
    public class OkDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private void CloseDialog(string parameter)
        {

            ButtonResult result = ButtonResult.None;
            result = parameter == "Yes" ? ButtonResult.Yes : ButtonResult.No;

            DialogParameters parameters = new DialogParameters();
            parameters.Add("Message", Message);

            RaiseRequestClose(new DialogResult(result, parameters));

        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _caption;

        public string Caption
        {
            get { return _caption; }
            set { SetProperty(ref _caption, value); }
        }

        public string Title => "Ok Dialog";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {


        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Caption = parameters.GetValue<string>("Caption");
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
    }
}
