using MvvmDialogs;

namespace DialogCommsDemo.Interfaces
{
    public interface IDialogViewModel : IModalDialogViewModel
    {
        bool OnClosing();

        IDialogConsumer Owner { get; }
    }
}