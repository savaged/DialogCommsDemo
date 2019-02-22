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

            ShowAnotherDialogCmd = new RelayCommand(OnShowAnotherDialog);

            _dialogViewModel.DialogClosed += OnDialogClosed;
        }

        public RelayCommand ShowDialogCmd { get; }

        public RelayCommand ShowAnotherDialogCmd { get; }

        public string DialogOutput
        {
            get => _dialogOutput;
            set => Set(ref _dialogOutput, value);
        }

        private void OnShowDialog()
        {
            _dialogService.Show(this, _dialogViewModel);
        }

        private void OnShowAnotherDialog()
        {
            _dialogService.Show(this, new AnotherDialogViewModel(this));
        }

        private void OnDialogClosed(object sender, IDialogClosedEventArgs e)
        {
            DialogOutput = e.DialogResult?.ToString();
        }
    }
}