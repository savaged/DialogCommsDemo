using DialogCommsDemo.Interfaces;
using System.ComponentModel;
using System.Windows;

namespace DialogCommsDemo.Views
{
    public partial class SubDialog : Window
    {
        public SubDialog()
        {
            InitializeComponent();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (DataContext is IDialogViewModel dialog)
            {
                e.Cancel = dialog.OnClosing();
            }
        }
    }
}
