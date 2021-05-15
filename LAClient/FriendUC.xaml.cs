using LAClient.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for Friend.xaml
    /// </summary>
    public partial class FriendUC : UserControl
    {
        private User friend;

        // public User Friend {get return friend; SetBinding friend = value; }
        public User Friend { get => friend; set => friend = value; }

        public EventHandler NavProfile;
        private Service1Client sr = new Service1Client();

        public FriendUC()
        {
            InitializeComponent();
            //this.DataContext = friend;
        }

        public FriendUC(User friends) : this()
        {
            // InitializeComponent();
            this.friend = friends;
            this.DataContext = friend;
            this.FollowButton.Content = sr.CheckFollowState(MainPage.CurrentUser, friend);
        }

        private void ShowMeetings_Click(object sender, RoutedEventArgs e)
        {
            ShowMeetingsPU smpu = new ShowMeetingsPU(friend);
            smpu.ShowDialog();
        }

        private void FollowButton_Click(object sender, RoutedEventArgs e)
        {
            sr.Friend(MainPage.CurrentUser, friend);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (NavProfile != null)
            {
                NavProfile(this.friend, null);
            }
        }
    }
}