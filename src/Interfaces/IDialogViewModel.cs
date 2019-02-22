using MvvmDialogs;
using System;

namespace DialogCommsDemo.Interfaces
{
    public interface IDialogViewModel : IModalDialogViewModel
    {
        bool OnClosing();

        IDialogConsumer Owner { get; }

        event EventHandler<IDialogClosedEventArgs> DialogClosed;
    }
}