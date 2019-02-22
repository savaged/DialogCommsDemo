using DialogCommsDemo.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace DialogCommsDemo.ViewModels
{
    public class DialogViewModel : DialogResultViewModelBase, IDialogConsumer
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

            _dialogViewModel.DialogClosed += OnDialogClosed;
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

        private void OnDialogClosed(object sender, IDialogClosedEventArgs e)
        {
            DialogOutput = e.DialogResult?.ToString();
        }
    }
}
