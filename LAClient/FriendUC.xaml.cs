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

        private event EventHandler refresh;
        private Service1Client sr = new Service1Client();

        public FriendUC()
        {
            InitializeComponent();
            //this.DataContext = friend;
        }

        public FriendUC(User _friend, EventHandler _refresh) : this()
        {
            // InitializeComponent();
            this.friend = _friend;
            this.refresh = _refresh;
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
            refresh(this, null);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var imagePopUp = new ImagePU(friend.Image);
            imagePopUp.ShowDialog();
        }
    }
}