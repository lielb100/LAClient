using LAClient.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private Service1Client sr;
        private int count = 0;

        public LoginPage()
        {
            InitializeComponent();
            sr = new Service1Client();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = emailbox.Text;
                string password = passbox.Password;
                User us1 = sr.CheckLogin(email, password);
                if (us1 != null && !(count >= 5))
                {
                    //MainWindow.User = us1;
                    //MainWindow.Frame.Navigate(new Home() { RemoveFromJournal = true });
                    if (us1.Manager)
                    {
                        NavigationService nav = NavigationService.GetNavigationService(this);
                        nav.Navigate(new MainPage(us1));
                    }
                    else
                    {
                        MessageBox.Show("Error, you are not an admin");
                        Application.Current.Shutdown();
                    }
                }
                else
                {
                    MessageBox.Show("Email or Password are incorect");
                    count++;
                    if (count >= 5)
                    {
                        MessageBox.Show("Sorry, too many unsuccessful login attempts. you have currently been locked");
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void Navigatereg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new RegisterPage());
        }

        private void fillbttn_Click(object sender, RoutedEventArgs e)
        {
            passbox.Password = "aa";
            emailbox.Text = "a@a.com";
        }
    }
}