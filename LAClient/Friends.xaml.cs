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
        private Service1Client sr = new Service1Client();

        public Friends()
        {
            InitializeComponent();
            foreach (User p in sr.GetAllFriendsByUser(MainPage.CurrentUser))
            {
                FriendUC friendUC = new FriendUC(p);
                friendUC.NavProfile = NavToProfile;
                this.AllFriends.Children.Add(friendUC);
            }
        }

        private void NavToProfile(object sender, EventArgs e)
        {
            User us = sender as User;
        }
    }
}

//    private Service1Client sr = new Service1Client();

//    public Friends()
//    {
//        InitializeComponent();
//        meetings.Visibility = Visibility.Hidden;
//        exit.Visibility = Visibility.Hidden;
//        foreach (User p in MainPage.CurrentUser.Friendships)
//        {
//            WrapPanel child = new WrapPanel();
//            child.VerticalAlignment = VerticalAlignment.Top;
//            child.Orientation = Orientation.Horizontal;
//            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
//            img.Source = (sr.GetImage(p.Image));
//            child.Children.Add(img);
//            TextBlock txt = new TextBlock();
//            System.Windows.Controls.Image verif = new System.Windows.Controls.Image();

//            txt.Text = "Name: " + p.FullName + Environment.NewLine + "Age: " + p.Age + Environment.NewLine + "Info: " + p.Info + "Phone number: " + p.Phone;
//            child.Children.Add(txt);
//            if (p.IsVer)
//            {
//                child.Children.Add(verif);
//            }
//            Button b = new Button();
//            b.Content = "Show meetings";

//            b.MouseDown += (sender, e) => fshowmeetings(p, sender, e);
//            child.Children.Add(b);

//            Button c = new Button
//            {
//                Content = "Show meetings"
//            };

//            c.MouseDown += (sender, e) => unfriend(child, p, sender, e);
//            child.Children.Add(c);

//            wrappy.Children.Add(child);
//        }
//    }

//    private void unfriend(WrapPanel child, User u, object sender, MouseButtonEventArgs e)
//    {
//        sr.Friend(MainPage.CurrentUser, u);
//        wrappy.Children.Remove(child);
//    }

//    private void fshowmeetings(User u, object sender, MouseButtonEventArgs e)
//    {
//        meetings.Visibility = Visibility.Visible;
//        exit.Visibility = Visibility.Visible;
//        FriendsMeetingList list = sr.GetAllMeetingsByUsers(MainPage.CurrentUser, u);
//        foreach (FriendsMeeting f in list)
//        {
//            TextBlock times = new TextBlock();
//            times.Text = f.Time.ToString();
//            meetings.Children.Add(times);
//        }
//    }

//    private void Exit_Click(object sender, RoutedEventArgs e)
//    {
//        meetings.Children.Clear();
//        meetings.Visibility = Visibility.Hidden;
//        exit.Visibility = Visibility.Hidden;
//    }
//}