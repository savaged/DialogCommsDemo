using CommonServiceLocator;
using DialogCommsDemo.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;
using System;

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

            ShowModalDialogCmd = new RelayCommand(OnShowModalDialog);

            _dialogViewModel.DialogClosed += OnDialogClosed;
        }

        public RelayCommand ShowDialogCmd { get; }

        public RelayCommand ShowAnotherDialogCmd { get; }

        public RelayCommand ShowModalDialogCmd { get; }

        public string DialogOutput
        {
            get => _dialogOutput;
            set => Set(ref _dialogOutput, value);
        }

        /// <summary>
        /// The dialog result is captured in the event 
        /// wired up in the ctor above like this:
        /// _dialogViewModel.DialogClosed += OnDialogClosed;
        /// which can do something like:
        /// bool? result = e.DialogResult;
        /// Alternatively the event could be wired in the 
        /// RelayCommand event, however care is needed to 
        /// ensure it doesn't get re-wired on each event by
        /// unwiring it in the OnDialogClosed event handler.
        /// </summary>
        private void OnShowDialog()
        {
            _dialogService.Show(this, _dialogViewModel);
        }

        private void OnShowAnotherDialog()
        {
            _dialogService.Show(this, new AnotherDialogViewModel(this));
        }

        /// <summary>
        /// Modal dialogs still work as expected
        /// </summary>
        private void OnShowModalDialog()
        {
            var result = _dialogService.ShowDialog(this, _dialogViewModel);
            if (result is null)
            {
                throw new InvalidOperationException(
                    "Expected the dialog to always return a valid boolean value!");
            }
            DialogOutput = result.ToString();
        }

        private void OnDialogClosed(object sender, IDialogClosedEventArgs e)
        {
            DialogOutput = e.DialogResult?.ToString();
        }
    }
}