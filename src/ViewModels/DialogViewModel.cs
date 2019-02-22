using DialogCommsDemo.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace DialogCommsDemo.ViewModels
{
    public class DialogViewModel : DialogViewModelBase, IDialogConsumer
    {
        private readonly SubDialogViewModel _dialogViewModel;
        private readonly IDialogService _dialogService;

        private string _dialogOutput;

        public DialogViewModel(IDialogConsumer owner, IDialogService dialogService) 
            : base(owner)
        {
            _dialogService = dialogService;

            _dialogViewModel = new SubDialogViewModel(this);

            ShowDialogCmd = new RelayCommand(OnShowDialog);

            MessengerInstance.Register<DialogResultMessage>(
                this, nameof(SubDialogViewModel), OnDialogClosed);
        }

        public RelayCommand ShowDialogCmd { get; }

        public string DialogOutput
        {
            get => _dialogOutput;
            set => Set(ref _dialogOutput, value);
        }

        private void OnShowDialog()
        {
            _dialogService.Show(this, _dialogViewModel);
        }

        private void OnDialogClosed(DialogResultMessage m)
        {
            DialogOutput = m.DialogResult?.ToString();
        }
    }
}
