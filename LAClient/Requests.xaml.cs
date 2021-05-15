using LAClient.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for Requests.xaml
    /// </summary>
    public partial class Requests : Page
    {
        private Service1Client sr = new Service1Client();

        public Requests()
        {
            InitializeComponent();
            UserList list = sr.GetAllRequestedByUser(MainPage.CurrentUser);
            foreach (User p in list)
            {
                RequestUC ruc = new RequestUC();
                ruc.Friend = p;
                wrappy.Children.Add(ruc);

                //WrapPanel child = new WrapPanel();
                //child.VerticalAlignment = VerticalAlignment.Top;
                //child.Orientation = Orientation.Horizontal;
                //System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                //img.Source = new BitmapImage(new Uri(p.Images[0].Img));
                //child.Children.Add(img);
                //TextBlock txt = new TextBlock();
                //System.Windows.Controls.Image verif = new System.Windows.Controls.Image();
                //verif.Source = new BitmapImage(new Uri("Assets\verbadge.png"));

                //txt.Text = "Name: " + p.FullName + Environment.NewLine + "Age: " + p.Age + Environment.NewLine + "Info: " + p.Info;
                //child.Children.Add(txt);
                //if (p.IsVer)
                //{
                //    child.Children.Add(verif);
                //}
                //Button b = new Button();
                //b.Content = "Show meetings";
                //b.MouseDown += (sender, e) => rshowmeetings(p, sender, e);
                //child.Children.Add(b);
                //Button ad = new Button();
                //ad.Content = "Accept Request";
                //ad.MouseDown += (sender, e) => accept(p, sender, e);

                //child.Children.Add(b);

                //wrappy.Children.Add(child);
            }
        }

        private void accept(User u, object sender, MouseButtonEventArgs e)
        {
            sr.Friend(MainPage.CurrentUser, u);
        }

        private void rshowmeetings(User u, Object sender, MouseButtonEventArgs e)
        {
            meetings.Visibility = Visibility.Visible;
            exit.Visibility = Visibility.Visible;
            FriendsMeetingList list = sr.GetAllMeetingsByUsers(MainPage.CurrentUser, u);
            foreach (FriendsMeeting f in list)
            {
                TextBlock times = new TextBlock();
                times.Text = f.Time.ToString();
                meetings.Children.Add(times);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            meetings.Children.Clear();
            meetings.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;
        }
    }
}