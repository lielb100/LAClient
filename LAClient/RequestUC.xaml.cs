using LAClient.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for RequestUC.xaml
    /// </summary>
    public partial class RequestUC : UserControl
    {
        private Service1Client sc = new Service1Client();
        private User friend;

        public User Friend { get => friend; set => friend = value; }
        private event EventHandler refresh;

        private RequestUC()
        {
            InitializeComponent();
        }

        public RequestUC(User friends, EventHandler _refresh) : this()
        {
            this.friend = friends;
            this.DataContext = friend;
            this.refresh = _refresh;

        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            sc.Friend(MainPage.CurrentUser, friend);
            refresh(this, null);
        }

        private void ShowMeetings_Click(object sender, RoutedEventArgs e)
        {
            ShowMeetingsPU smpu = new ShowMeetingsPU(friend);
            smpu.ShowDialog();
        }

        private void IgnoreButton_Click(object sender, RoutedEventArgs e)
        {
            sc.DeclineRequest(MainPage.CurrentUser, friend);
            refresh(this, null);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImagePU ipu = new ImagePU(friend.Image);
            ipu.ShowDialog();
        }
    }
}