using LAClient.ServiceReference1;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for AdminFriendsPU.xaml
    /// </summary>
    ///

    internal class FriendShipUserDC
    {
        private User theUser;
        private Friendship theFriendship;
        //private FriendsMeeting theFriendship;

        public User TheUser { get => theUser; set => theUser = value; }
        public Friendship TheFriendship { get => theFriendship; set => theFriendship = value; }
        //public Friendship TheFriendship { get => theFriendship; set => theFriendship = value; }
    }

    public partial class AdminFriendsPU : Window
    {
        private User user;
        public User User { get => user; set => user = value; }
        private Service1Client sc;

        public AdminFriendsPU()
        {
            InitializeComponent();
            FriendsView.ItemsSource = null;
            sc = new Service1Client();
        }

        public AdminFriendsPU(User us1) : this()
        {
            this.user = us1;
            Header.Text = $"{user.FullName}'s Friends";
            FriendshipList friendships = sc.GetAllFriendshipsByUser(user);
            List<FriendShipUserDC> DC = new List<FriendShipUserDC>();

            foreach (var friendship in friendships)
            {
                User us = sc.GetUserByID(friendship.Friend1 == user.ID ? friendship.Friend2 : friendship.Friend1);

                DC.Add(new FriendShipUserDC { TheUser = us, TheFriendship = friendship });
            }
            this.FriendsView.ItemsSource = DC;
        }

        private void ShowMeetingsPU_Click(object sender, RoutedEventArgs e)
        {
            ShowMeetingsPU showMeetingsPU = new ShowMeetingsPU((((Button)sender).DataContext as FriendShipUserDC).TheUser, user);
            showMeetingsPU.ShowDialog();
        }
    }
}