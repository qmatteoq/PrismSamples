using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloMvvm.Dialogs
{
    public static class DialogServiceHelper
    {
        public static Task<IDialogResult> ShowDialogAsync(this IDialogService dialogService, string name, DialogParameters parameters)
        {
            TaskCompletionSource<IDialogResult> tcs = new TaskCompletionSource<IDialogResult>();
            dialogService.ShowDialog(name, parameters, result =>
            {
                tcs.SetResult(result);
            });

            return tcs.Task;
        }

    }
}
