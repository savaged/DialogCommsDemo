using CommonServiceLocator;
using DialogCommsDemo.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace DialogCommsDemo.ViewModels
{
    public class MainViewModel : ViewModelBase, IDialogConsumer
    {
        private readonly DialogViewModel _dialogViewModel;
        private readonly IDialogService _dialogService;

        private string _dialogOutput;

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            _dialogViewModel = new DialogViewModel(this, _dialogService);

            ShowDialogCmd = new RelayCommand(OnShowDialog);

            MessengerInstance.Register<DialogResultMessage>(
                this, nameof(DialogViewModel), OnDialogClosed);
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