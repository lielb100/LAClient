using LAClient.ServiceReference1;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Home : Page
    {
        private Service1Client sr = new Service1Client();

        private bool removeFromJournal = false;
        public static Frame Frame;

        public Home()
        {
            InitializeComponent();
        }

        public bool RemoveFromJournal
        {
            get { return removeFromJournal; }
            set { removeFromJournal = value; }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.RemoveFromJournal)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.RemoveBackEntry();
            }
        }

        #region
        //private void Activebttn_Click(object sender, RoutedEventArgs e)
        //{
        //    //MainWindow.User.Seen = true;
        //    activebttn.Content = "Stop";
        //    WrapPanel wrap = new WrapPanel();
        //    wrap.Width = 797;
        //    wrap.VerticalAlignment = VerticalAlignment.Top;
        //    wrap.HorizontalAlignment = HorizontalAlignment.Left;

        //    UserList around = sr.GetUsersNear(MainWindow.User);

        //     foreach(User u in around)
        //    {
        //        Profile p = new Profile(u);
        //        WrapPanel child = new WrapPanel();
        //        child.VerticalAlignment = VerticalAlignment.Top;
        //        child.Orientation = Orientation.Horizontal;
        //        System.Windows.Controls.Image img = new System.Windows.Controls.Image();
        //        img.Source = new BitmapImage(new Uri(p.Profilepic.Img));
        //        child.Children.Add(img);
        //        TextBlock txt = new TextBlock();
        //        System.Windows.Controls.Image verif = new System.Windows.Controls.Image();
        //        verif.Source = new BitmapImage(new Uri("Assets\verbadge.png"));

        //        txt.Text = "Name: "+p.Name +Environment.NewLine +"Age: "+p.Age+Environment.NewLine+ "Info: "+ p.Info;
        //        child.Children.Add(txt);
        //        if (p.Ver)
        //        {
        //            child.Children.Add(verif);
        //        }
        //        Button b = new Button();
        //        b.Content = "Show meetings";

        //        b.MouseDown += (sender1, en) => hshowmeetings(u, sender1, en);
        //        child.Children.Add(b);

        //        wrap.Children.Add(child);

        //        }

        //}

        //private void hshowmeetings(User u, object sender1, MouseButtonEventArgs en)
        //{
        //    meetings.Visibility = Visibility.Visible;
        //    exit.Visibility = Visibility.Visible;
        //    FriendsMeetingList list = sr.GetAllMeetingsByUsers(MainWindow.User, u);
        //    foreach (FriendsMeeting f in list)
        //    {
        //        TextBlock times = new TextBlock();
        //        times.Text = f.Time.ToString();
        //        meetings.Children.Add(times);
        //    }
        //}

        //private void Exit_Click(object sender, RoutedEventArgs e)
        //{
        //    meetings.Children.Clear();
        //    meetings.Visibility = Visibility.Hidden;
        //    exit.Visibility = Visibility.Hidden;
        //}
        #endregion
    }
}