using DialogCommsDemo.Interfaces;
using GalaSoft.MvvmLight.Messaging;

namespace DialogCommsDemo
{
    public class DialogResultMessage : MessageBase
    {
        public DialogResultMessage(IDialogViewModel sender) 
            : base(sender, sender?.Owner)
        {
            DialogResult = sender?.DialogResult; 
        }

        public bool? DialogResult { get; }
    }
}
