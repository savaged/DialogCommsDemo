using System;

namespace DialogCommsDemo.Interfaces
{
    public interface IModalDialogViewModel : MvvmDialogs.IModalDialogViewModel
    {
        bool OnClosing();

        IDialogConsumer Owner { get; }

        event EventHandler<IDialogClosedEventArgs> DialogClosed;
    }
}