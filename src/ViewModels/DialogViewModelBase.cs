using DialogCommsDemo.Interfaces;
using GalaSoft.MvvmLight;

namespace DialogCommsDemo.ViewModels
{
    public abstract class DialogViewModelBase : ViewModelBase, IDialogViewModel
    {
        private bool? _dialogResult;

        public DialogViewModelBase(IDialogConsumer owner)
        {
            Owner = owner;
            DialogResult = false;
        }

        public bool? DialogResult
        {
            get => _dialogResult;
            set
            {
                Set(ref _dialogResult, value);
            }
        }

        public IDialogConsumer Owner { get; }

        public bool OnClosing()
        {
            var cancel = false;

            MessengerInstance.Send(new DialogResultMessage(this), GetType().Name);

            return cancel;
        }
    }
}
