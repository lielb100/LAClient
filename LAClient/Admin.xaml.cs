using LAClient.ServiceReference1;
using System.Windows;
using System.Windows.Controls;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private Service1Client sr = new Service1Client();

        private User user;
        private UserList Users;

        public Admin()
        {
            InitializeComponent();

            lstView2.ItemsSource = null; //force  refresh
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users = sr.SelectAllUsers();
            lstView2.ItemsSource = Users;
            txt.Content = Users.Count.ToString();
        }

        //private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    user = (User)lstView2.SelectedItem;
        //    grid.DataContext = user;
        //}

        //private void MenuItem_Verify(object sender, RoutedEventArgs e)
        //{
        //    user = lstView2.SelectedItem as User;

        //    //adminframe.Navigate(new VerAdmin(user, 1));
        //    //LessonsList lesson = dB.SelectByStudent(student.Id);
        //    //list.ItemsSource = lesson;
        //    //txt.Content = lesson.Count.ToString();
        //}

        private void MenuItem_Delete(object sender, RoutedEventArgs e)
        {
            User user = lstView2.SelectedItem as User;
            sr.DeleteUser(user);
            sr.SaveChanges();
            Users.Remove(user);
            lstView2.ItemsSource = null; //force  refresh
            lstView2.ItemsSource = Users;
        }

        public void ForceRefresh()
        {
            lstView2.ItemsSource = null; //force  refresh
            lstView2.ItemsSource = Users;
        }

        private void MenuItem_Update(object sender, RoutedEventArgs e)
        {
            user = lstView2.SelectedItem as User;
            var updatePU = new ProfilePU(user, this);
            updatePU.ShowDialog();
        }

        private void MenuItem_Friends(object sender, RoutedEventArgs e)
        {
            User user = lstView2.SelectedItem as User;
            AdminFriendsPU smpu = new AdminFriendsPU(user);
            smpu.ShowDialog();
        }

        private void InsertBttn_Click(object sender, RoutedEventArgs e)
        {
            RegisterPU registerPU = new RegisterPU(this);
            registerPU.ShowDialog();
        }

        //private void Button_Click1(object sender, RoutedEventArgs e)
        //{
        //    adminframe.Navigate(new NonVer());
        //}
        //private static User veruser;
        //public static User Veruser

        //{
        //    get
        //    {
        //        return veruser;
        //    }

        //    set
        //    {
        //        veruser = value;
        //    }
        //}
    }
}