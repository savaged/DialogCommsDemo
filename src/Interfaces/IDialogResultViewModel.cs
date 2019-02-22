using System;

namespace DialogCommsDemo.Interfaces
{
    public interface IDialogResultViewModel : MvvmDialogs.IModalDialogViewModel
    {
        bool OnClosing();

        IDialogConsumer Owner { get; }

        event EventHandler<IDialogClosedEventArgs> DialogClosed;
    }
}