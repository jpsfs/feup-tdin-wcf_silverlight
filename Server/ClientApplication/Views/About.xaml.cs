namespace ClientApplication
{
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Windows;

    /// <summary>
    /// <see cref="Page"/> class to present information about the current application.
    /// </summary>
    public partial class About : Page
    {
        /// <summary>
        /// Creates a new instance of the <see cref="About"/> class.
        /// </summary>
        public About()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.AboutPageTitle;

            if (App.Current.IsRunningOutOfBrowser)
            {
                UpdateButton.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void UpdateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.Current.CheckAndDownloadUpdateCompleted += new System.Windows.CheckAndDownloadUpdateCompletedEventHandler(Current_CheckAndDownloadUpdateCompleted);
            App.Current.CheckAndDownloadUpdateAsync();
        }

        void Current_CheckAndDownloadUpdateCompleted(object sender, System.Windows.CheckAndDownloadUpdateCompletedEventArgs e)
        {
            if (e.Error == null && e.UpdateAvailable)
            {
                MessageBox.Show("New version installed! Please restart!");
            }
            else
            {
                MessageBox.Show("No new version available at this time. Please try again later.");
            }
        }

  
    }
}