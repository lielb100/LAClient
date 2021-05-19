using LAClient.ServiceReference1;
using System;
using System.Windows.Controls;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for Friends.xaml
    /// </summary>
    public partial class Friends : Page
    {
        private Service1Client sr;

        public Friends()
        {
            InitializeComponent();
            Refresh(this, null);
        }

        private void Refresh(object sender, EventArgs e)
        {
            sr = new Service1Client();
            AllFriends.Children.Clear();
            foreach (User p in sr.GetAllFriendsByUser(MainPage.CurrentUser))
            {
                FriendUC friendUC = new FriendUC(p, Refresh);
                this.AllFriends.Children.Add(friendUC);
            }
        }
    }
}