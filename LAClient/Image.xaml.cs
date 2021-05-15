using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using LAClient.SRtoHost;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : Page
    {
        public Image(User user)
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "jpg files(*.jpg)|*jpg| PNG files(*.png)|*.png| All files(*.*)|*.*|",
                    Title = "Choose your profie picture"
                };
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Uri fileUri = new Uri(dialog.FileName);
                    image1.Source = new BitmapImage(fileUri);
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Bitmap snapshot = new Bitmap(image1.Source.ToString());

            // Save in some directory
            // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
            // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
            snapshot.Save(string.Format(@"C:\Users\sdkca\Desktop\{0}.png", Guid.NewGuid()), ImageFormat.Png);

           
            imageFrame.Navigate(new Home());
        }
    }
}
