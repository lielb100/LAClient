using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LAClient.SRtoHost;
namespace LAClient
{
    /// <summary>
    /// Interaction logic for NonVer.xaml
    /// </summary>
    public partial class NonVer : Page
    {
        Service1Client sr = new Service1Client();

        User user;
        UserList users;
        public NonVer()
        {
            InitializeComponent();

            lstView2.ItemsSource = null; //force  refresh
            lstView2.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users = sr.GetAllNonVer();
            lstView2.ItemsSource = users;
            txt.Content = users.Count.ToString();
        }


        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user = (User)lstView2.SelectedItem;
            grid.DataContext = user;
        }

        private void MenuItem_lessons(object sender, RoutedEventArgs e)
        {
            user = lstView2.SelectedItem as User;
            Admin.Veruser = user;
            nonverframe.Navigate(new VerAdmin(0));
        }

       

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

            if (nonverframe.NavigationService.CanGoBack)
                nonverframe.NavigationService.GoBack();
        }


        
    }
}

