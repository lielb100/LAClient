using LAClient.ServiceReference1;
using System.Windows;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for ImagePU.xaml
    /// </summary>
    public partial class ImagePU : Window
    {
        private User friend;
        public User Friend { get => friend; set => friend = value; }

        public ImagePU()
        {
            InitializeComponent();
        }

        public ImagePU(User friends) : this()
        {
            // InitializeComponent();
            this.friend = friends;
            this.DataContext = friend;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}