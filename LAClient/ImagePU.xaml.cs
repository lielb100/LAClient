using LAClient.ServiceReference1;
using System.Windows;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for ImagePU.xaml
    /// </summary>
    public partial class ImagePU : Window
    {
        private string image;
        public string Image { get => image; set => image = value; }

        public ImagePU()
        {
            InitializeComponent();
        }

        public ImagePU(string _image) : this()
        {
            // InitializeComponent();
            this.image = _image;
            this.DataContext = image;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}