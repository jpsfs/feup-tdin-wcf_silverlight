namespace ClientApplication
{
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using ClientApplication.Models;
    /// <summary>
    /// Home page for the application.
    /// </summary>
    public partial class Home : Page
    {
        public static System.Collections.ObjectModel.ObservableCollection<Server.Transaction> datagridsource;

        /// <summary>
        /// Creates a new <see cref="Home"/> instance.
        /// </summary>
        public Home()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.HomePageTitle;

            WebContext.Current.Authentication.LoggedIn += new System.EventHandler<System.ServiceModel.DomainServices.Client.ApplicationServices.AuthenticationEventArgs>(Authentication_LoggedIn);
            WebContext.Current.Authentication.LoggedOut += new System.EventHandler<System.ServiceModel.DomainServices.Client.ApplicationServices.AuthenticationEventArgs>(Authentication_LoggedOut);

            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("ID", "N"));
            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("ClientName", "Client"));
            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("StockType", "Stock Type"));
            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("Quantity", "Quantity"));
            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("Type", "Type"));
            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("State", "State"));
            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("Time", "Date"));
            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("StockValue", "Stock Value"));
            TransactionsDataGrid.Columns.Add(App.CreateTextColumn("OperationValue", "Operation Value"));

        }

        void Authentication_LoggedOut(object sender, System.ServiceModel.DomainServices.Client.ApplicationServices.AuthenticationEventArgs e)
        {
            this.LoggedInBorder.Visibility = System.Windows.Visibility.Collapsed;
            this.RequireLoginBorder.Visibility = System.Windows.Visibility.Visible;
            
        }

        void Authentication_LoggedIn(object sender, System.ServiceModel.DomainServices.Client.ApplicationServices.AuthenticationEventArgs e)
        {
            this.RequireLoginBorder.Visibility = System.Windows.Visibility.Collapsed;
            this.LoggedInBorder.Visibility = System.Windows.Visibility.Visible;

            home_LoadTransactionList();
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           if (WebContext.Current.User.IsAuthenticated)
            {
                this.RequireLoginBorder.Visibility = System.Windows.Visibility.Collapsed;
                this.LoggedInBorder.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.LoggedInBorder.Visibility = System.Windows.Visibility.Collapsed;
                this.RequireLoginBorder.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public void home_LoadTransactionList()
        {
            textBoxSearch.Text = "";
            busyIndicatorGrid.IsBusy = true;
            App.client.ListTransactionCompleted += new System.EventHandler<Server.ListTransactionCompletedEventArgs>(client_ListTransactionCompleted);
            App.client.ListTransactionAsync();
        }

        void client_ListTransactionCompleted(object sender, Server.ListTransactionCompletedEventArgs e)
        {
            busyIndicatorGrid.IsBusy = false;
            if (e.Error == null)
            {
                if (e.Result.Count == 0)
                {
                    TransactionsDataGrid.Visibility = System.Windows.Visibility.Collapsed;
                    NoRecordsFoundTransactionsDataGrid.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    NoRecordsFoundTransactionsDataGrid.Visibility = System.Windows.Visibility.Collapsed;
                    datagridsource = e.Result;
                    TransactionsDataGrid.ItemsSource = datagridsource;
                    TransactionsDataGrid.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
                throw e.Error;
        }

        private void RefreshTransactionsDataGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            home_LoadTransactionList();
        }

        private void NewTransaction_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Views.Transaction.NewTransactionWindow newTransactionWindow = new Views.Transaction.NewTransactionWindow();
            newTransactionWindow.Closed += new System.EventHandler(newTransactionWindow_Closed);

            if (WebContext.Current.User.Role == ((int)Server.ClientRole.admin).ToString())
            {
                TransactionInfoBalcon transactionInfo = new TransactionInfoBalcon();
                newTransactionWindow.newTransactionForm.CurrentItem = transactionInfo;

                App.client.ListClientsEmailCompleted += new System.EventHandler<Server.ListClientsEmailCompletedEventArgs>(client_ListClientsEmailCompleted);
                App.client.ListClientsEmailAsync();
            }
            else
            {
                TransactionInfo transactionInfo = new TransactionInfo();
                newTransactionWindow.newTransactionForm.CurrentItem = transactionInfo;
            }

            newTransactionWindow.Show();
        }

        void client_ListClientsEmailCompleted(object sender, Server.ListClientsEmailCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ClientApplication.Models.TransactionValidator.clientsEmails = e.Result;
            }
            else throw e.Error;
        }

        void newTransactionWindow_Closed(object sender, System.EventArgs e)
        {
            Views.Transaction.NewTransactionWindow childWindow = sender as Views.Transaction.NewTransactionWindow;
            if (childWindow.DialogResult == true)
            {
                home_LoadTransactionList();
            }
        }

        private void textBoxSearch_TextChanged(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            string searchKey = (sender as TextBox).Text.Trim().ToLower();
            
            System.Collections.ObjectModel.ObservableCollection<Server.Transaction> newList = new System.Collections.ObjectModel.ObservableCollection<Server.Transaction>();
            foreach (Server.Transaction t in datagridsource)
            {
                if (t.ClientName.ToLower().IndexOf(searchKey) != -1)
                {
                    newList.Add(t);
                }
            }
            
            TransactionsDataGrid.ItemsSource = newList;
        }

    }
}