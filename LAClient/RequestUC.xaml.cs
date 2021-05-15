using LAClient.ServiceReference1;
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

        public RequestUC()
        {
            InitializeComponent();
        }

        public RequestUC(User friends) : this()
        {
            // InitializeComponent()
            this.friend = friends;
            this.DataContext = friend;
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            sc.Friend(MainPage.CurrentUser, friend);
        }

        private void ShowMeetings_Click(object sender, RoutedEventArgs e)
        {
            ShowMeetingsPU smpu = new ShowMeetingsPU(friend);
            smpu.ShowDialog();
        }

        private void IgnoreButton_Click(object sender, RoutedEventArgs e)
        {
            sc.DeclineRequest(MainPage.CurrentUser, friend);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImagePU ipu = new ImagePU();
            ipu.Friend = friend;
            ipu.ShowDialog();
        }
    }
}