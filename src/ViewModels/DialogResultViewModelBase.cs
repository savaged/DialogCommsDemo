using DialogCommsDemo.Interfaces;
using GalaSoft.MvvmLight;
using System;

namespace DialogCommsDemo.ViewModels
{
    /// <summary>
    /// When implementing this don't forget to include the changes to the
    /// dialog Window - add a Closing event like this:
    /// void OnClosing(object sender, CancelEventArgs e)
    /// {
    ///     if (DataContext is IDialogResultViewModel dialog)
    ///     {
    ///        e.Cancel = dialog.OnClosing();
    ///     }
    /// }
    /// </summary>
    public abstract class DialogResultViewModelBase : ViewModelBase, IDialogResultViewModel
    {
        private bool? _dialogResult;

        public DialogResultViewModelBase(IDialogConsumer owner)
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

        /// <summary>
        /// Override to return bool for Window event
        /// void OnClosing(object sender, CancelEventArgs e)
        /// {
        ///    if (DataContext is IDialogViewModel dialog)
        ///    {
        ///       e.Cancel = dialog.OnClosing();
        ///    }
        /// }
        /// </summary>
        /// <returns></returns>
        public virtual bool OnClosing()
        {
            var cancel = false;

            RaiseDialogClosed();

            return cancel;
        }

        private void RaiseDialogClosed()
        {
            var handler = DialogClosed;
            var args = new DialogClosedEventArgs(DialogResult);
            handler?.Invoke(this, args);
        }
        public event EventHandler<IDialogClosedEventArgs> DialogClosed = delegate { };
    }
}
