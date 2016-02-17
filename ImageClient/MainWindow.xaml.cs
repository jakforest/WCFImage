using System.Windows;
using ImageClient.ViewModel;
using ImageClient.Pages;
using System.Windows.Controls;

namespace ImageClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            RootFrame.Content = new MainPage();
        }

        private void RootFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if ((RootFrame.Content != null) && (((Page)RootFrame.Content).DataContext is MainViewModel))
                ((MainViewModel)DataContext).OnNavigating(null);
        }
    }
}