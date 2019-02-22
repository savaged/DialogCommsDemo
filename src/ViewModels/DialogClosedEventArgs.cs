using DialogCommsDemo.Interfaces;
using System;

namespace DialogCommsDemo.ViewModels
{
    public class DialogClosedEventArgs : EventArgs, IDialogClosedEventArgs
    {
        public DialogClosedEventArgs(bool? dialogResult)
        {
            DialogResult = dialogResult;
        }

        public bool? DialogResult { get; }
    }
}
