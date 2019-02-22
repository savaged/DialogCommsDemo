using MvvmDialogs;
using System;

namespace DialogCommsDemo.Interfaces
{
    public interface IDialogResultViewModel : IModalDialogViewModel
    {
        bool OnClosing();

        IDialogConsumer Owner { get; }

        event EventHandler<IDialogClosedEventArgs> DialogClosed;
    }
}