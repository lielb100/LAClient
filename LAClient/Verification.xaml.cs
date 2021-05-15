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
using LAClient.SRtoHost;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Threading;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for Verification.xaml
    /// </summary>
    public partial class Verification : Page
    {
        VideoCapture capture;
            Mat frame;
            Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;
   


        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBox1.Source != null)
                    {
                        pictureBox1.Source=null;
                    }
                    Uri fileUri = new Uri(image.ToString());
                    pictureBox1.Source = new BitmapImage(fileUri);
                }
            }
        }

        public Verification()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // When the user clicks on the start/stop button, start or release the camera and setup flags
       private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
 if (button1.Content.Equals("Start"))
            {
                CaptureCamera();
                button1.Content = "Stop";
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                button1.Content = "Start";
                isCameraRunning = false;
            }
        }

        // When the user clicks on take snapshot, the image that is displayed in the pictureBox will be saved in your computer
        private void Button2_Click_1(object sender, RoutedEventArgs e)
        {

            if (isCameraRunning)
            {
                // Take snapshot of the current image generate by OpenCV in the Picture Box
                Bitmap snapshot = new Bitmap(pictureBox1.Source.ToString());

                // Save in some directory
                // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                snapshot.Save(string.Format(@"C:\Users\sdkca\Desktop\{0}.png", Guid.NewGuid()), ImageFormat.Png);

                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Home());
            }
            else
            {
                Console.WriteLine("Cannot take picture if the camera isn't capturing image!");
            }
        }
    }
}

