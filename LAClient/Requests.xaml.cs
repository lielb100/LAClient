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
        private Service1Client sr;

        public Requests()
        {
            InitializeComponent();
            refresh(this, null);
        }

        private void refresh(object sender, EventArgs e)
        {
            sr = new Service1Client();
            wrappy.Children.Clear();
            UserList list = sr.GetAllRequestedByUser(MainPage.CurrentUser);
            foreach (User p in list)
            {
                RequestUC ruc = new RequestUC(p, refresh);
                wrappy.Children.Add(ruc);
            }
        }
    }
}