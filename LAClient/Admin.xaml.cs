using LAClient.ServiceReference1;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private Service1Client sr = new Service1Client();
        private Window updateInsertWindow;
        private User user;
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users { get => users; set => users = value; }


        public Admin()
        {
            InitializeComponent();

            lstView2.ItemsSource = null; //force  refresh
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<User>( sr.SelectAllUsers());
            lstView2.ItemsSource = users;
            //Binding binding = new Binding { Converter = new IntToString(), Path = new PropertyPath(users.Count) };
            //txt.SetBinding(ContentProperty, binding);
            txt.Content = users.Count;
        }

        private void EndPopUp(object sender, EventArgs e)
        {
            updateInsertWindow.Close();
            forceRefresh();
        }

        private void forceRefresh()
        {
            lstView2.ItemsSource = null; //force  refresh
            lstView2.ItemsSource = users;
        }

        private void InsertBttn_Click(object sender, RoutedEventArgs e)
        {
            updateInsertWindow = new Window();
            updateInsertWindow.Content = new RegisterUpdateUC(EndPopUp);
            updateInsertWindow.ShowDialog();
        }

        private void MenuItem_Delete(object sender, RoutedEventArgs e)
        {
            User user = lstView2.SelectedItem as User;
            sr.DeleteUser(user);
            Users.Remove(user);
            forceRefresh();
        }

        private void MenuItem_Friends(object sender, RoutedEventArgs e)
        {
            User user = lstView2.SelectedItem as User;
            AdminFriendsPU smpu = new AdminFriendsPU(user);
            smpu.ShowDialog();
        }

        private void MenuItem_Update(object sender, RoutedEventArgs e)
        {
            user = lstView2.SelectedItem as User;
            updateInsertWindow = new Window();
            updateInsertWindow.Content = new RegisterUpdateUC(ObjectCopier.CloneJson(user), EndPopUp);
            updateInsertWindow.ShowDialog();
        }
    }
}