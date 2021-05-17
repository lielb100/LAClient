using LAClient.ServiceReference1;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private static User currentUser;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(User user) : this()
        {
            currentUser = user;
        }

        public static User CurrentUser
        {
            get => currentUser;
            set => currentUser = value;
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
        }

        private void HamburgerMenuItem_Selected_3(object sender, RoutedEventArgs e)
        {
            if (myFrame.NavigationService.CanGoBack)
                myFrame.NavigationService.GoBack();
        }

        private void HamburgerMenuItem_Selected_4(object sender, RoutedEventArgs e)
        {
            if (myFrame.NavigationService.CanGoForward)
                myFrame.NavigationService.GoForward();
        }

        private void HomeOne_Selected(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new Home());
        }

        private void AdminOne_Selected(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new Admin());
        }

        private void FriendsOne_Selected(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new Friends());
        }

        private void ProfileOne_Selected(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ProfilePage());
        }
    }
}