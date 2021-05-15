using LAClient.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LAClient
{
    public partial class Register : Page
    {
        private Service1Client sr = new Service1Client();

        private PreferenceList plist;
        private SexList slist;
        private User s;

        public Register()
        {
            InitializeComponent();
            this.s = new User();
            this.DataContext = s;
            slist = sr.GetAllSexes();
            this.SexBox.ItemsSource = slist;
            plist = sr.GetAllPreferences();
            this.PreBox.ItemsSource = plist;
            this.DataContext = s;
            dp.DisplayDateEnd = DateTime.Now;
            dp.DisplayDateStart = DateTime.Now.AddYears(-120);
        }

        public Register(User user) : this()
        {
            // InitializeComponent();

            this.s = user;

            this.s.Sex = (this.slist.Find(c => c.ID == s.Sex.ID));
            this.s.Preference = (this.plist.Find(p => p.ID == s.Preference.ID));

            this.DataContext = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (s.ID == 0)
            {
                sr.Insert(s);
            }
            else
            {
                sr.UpdateUser(s);
            }

            sr.SaveChanges();

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MainPage(s));
        }

        private void SexBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void PreBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());
        }
    }
}