using LAClient.ServiceReference1;
using System.Windows;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for ShowMeetingsPU.xaml
    /// </summary>
    public partial class ShowMeetingsPU : Window
    {
        private User friend;
        public User Friend { get => friend; set => friend = value; }

        public User MainUser { get => mainUser; set => mainUser = value; }
        private User mainUser;

        private Service1Client sr = new Service1Client();

        public ShowMeetingsPU()
        {
            InitializeComponent();
        }

        public ShowMeetingsPU(User friends) : this()
        {
            this.friend = friends;
            this.mainUser = MainPage.CurrentUser;
            this.NamesBlock.Text = $"{mainUser.FullName}'s and {friend.FullName}'s meetings";
            this.AllMeetings.ItemsSource = sr.GetAllMeetingsByUsers(friend, mainUser);
        }

        public ShowMeetingsPU(User friends, User main) : this()
        {
            this.friend = friends;
            this.mainUser = main;
            this.NamesBlock.Text = $"{mainUser.FullName}'s and {friend.FullName}'s meetings";
            this.AllMeetings.ItemsSource = sr.GetAllMeetingsByUsers(friend, mainUser);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}