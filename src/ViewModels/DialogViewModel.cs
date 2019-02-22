using DialogCommsDemo.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;
using System;

namespace DialogCommsDemo.ViewModels
{
    public class DialogViewModel : DialogResultViewModelBase, IDialogConsumer
    {
        private readonly IDialogService _dialogService;

        private string _dialogOutput;

        public DialogViewModel(IDialogConsumer owner, IDialogService dialogService) 
            : base(owner)
        {
            _dialogService = dialogService;

            ShowDialogCmd = new RelayCommand(OnShowDialog);
        }

        public RelayCommand ShowDialogCmd { get; }

        public string DialogOutput
        {
            get => _dialogOutput;
            set => Set(ref _dialogOutput, value);
        }

        /// <summary>
        /// The dialog result is captured in the event 
        /// which can do something like:
        /// bool? result = e.DialogResult;
        /// Alternatively the event could be wired in the ctor.
        /// </summary>
        private void OnShowDialog()
        {
            var vm = new SubDialogViewModel(this);
            vm.DialogClosed += OnDialogClosed;
            try
            {
                _dialogService.Show(this, vm);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(
                    "Pretty sure this is a fault in MvvmDialogs.");
                throw;
            }
        }

        private void OnDialogClosed(object sender, IDialogClosedEventArgs e)
        {
            DialogOutput = e.DialogResult?.ToString();
            var vm = (IDialogResultViewModel)sender;
            vm.DialogClosed -= OnDialogClosed;
        }
    }
}
