using LAClient.ServiceReference1;
using System;
using System.IO;

namespace LAClient
{
    public class ImageUtils
    {
        private static string imageDirectory = App.ImageDirectory;
        public static string ImageDirectory { get => imageDirectory; set => imageDirectory = value; }

        public static string UploadImage_Dlg()
        {
            string filename = null;

            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //OpenFileDialog dlg = new OpenFileDialog();    //->   need using Microsoft.Win32;

            // Set filter for file extension and default file extension
            //      dlg.DefaultExt = ".png";
            // dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dlg.Filter = "All Images | *.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.png|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
                filename = SaveImage(filename); // save the Picture in LocalFolder (if not exist) rns return only thr file name
            }

            return filename;
        }

        public static string SaveImage(string sourcefileName)
        {
            string fileName = System.IO.Path.GetFileName(sourcefileName);
            //            string localFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);
            string localFilePath = System.IO.Path.Combine(imageDirectory, fileName);
            //string localFilePath = System.IO.Path.Combine(App.ImageDirectory, fileName);
            if (!File.Exists(localFilePath))
            {
                byte[] imgArray = File.ReadAllBytes(sourcefileName);
                var stream = new MemoryStream(imgArray);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

                img.Save(localFilePath);
            }
            return fileName;
        }

        public static void SendImage(string image)
        {
            // string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + image);
            string path = System.IO.Path.Combine(imageDirectory, image);
            //string path = System.IO.Path.Combine(App.ImageDirectory, image);
            byte[] imgArray = File.ReadAllBytes(path);

            Service1Client serv = new Service1Client();
            serv.SaveImage(imgArray, image);
        }
    }
}