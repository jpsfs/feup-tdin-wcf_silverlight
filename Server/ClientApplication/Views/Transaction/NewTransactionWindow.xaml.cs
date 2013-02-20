using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using ClientApplication.Models;

namespace ClientApplication.Views.Transaction
{
    public partial class NewTransactionWindow : ChildWindow
    {
        public NewTransactionWindow()
        {

            InitializeComponent();
            newTransactionForm.EditEnded += new EventHandler<DataFormEditEndedEventArgs>(newTransactionForm_EditEnded);

        }

        void newTransactionForm_EditEnded(object sender, DataFormEditEndedEventArgs e)
        {
           
            busyIndicator.IsBusy = true;

            //Call Server
            if (WebContext.Current.User.Role == ((int)Server.ClientRole.admin).ToString())
            {
                TransactionInfoBalcon transactionInfo = newTransactionForm.CurrentItem as TransactionInfoBalcon;
                App.client.NewTransactionBalconCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(client_NewTransactionCompleted);
                App.client.NewTransactionBalconAsync(transactionInfo.ClientEmail, transactionInfo.Type, transactionInfo.Quantity, transactionInfo.SockType);
            }
            else
            {
                TransactionInfo transactionInfo = newTransactionForm.CurrentItem as TransactionInfo;
                App.client.NewTransactionCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(client_NewTransactionCompleted);
                App.client.NewTransactionAsync(transactionInfo.Type, transactionInfo.Quantity, transactionInfo.SockType);
            }
        }

        void client_NewTransactionCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            busyIndicator.IsBusy = false;
            if (e.Error == null)
            {
                this.DialogResult = true;
            }
            else
                throw e.Error;
                
        }

    }
}

