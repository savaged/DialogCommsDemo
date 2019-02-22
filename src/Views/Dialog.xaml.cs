using DialogCommsDemo.Interfaces;
using System.ComponentModel;
using System.Windows;

namespace DialogCommsDemo.Views
{
    public partial class Dialog : Window
    {
        public Dialog()
        {
            InitializeComponent();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (DataContext is IDialogResultViewModel dialog)
            {
                e.Cancel = dialog.OnClosing();
            }
        }
    }
}
