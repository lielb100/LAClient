using LAClient.ServiceReference1;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace LAClient
{
    public sealed class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                             object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            string fileName = (string)value;
            if (fileName == "") return null;

            // string path = Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);
            string path = System.IO.Path.Combine(ImageUtils.ImageDirectory, fileName);
            //string path = System.IO.Path.Combine(App.ImageDirectory, fileName);

            try
            {
                Uri uri = new Uri(fileName);// , UriKind.Relative);
                fileName = uri.Segments[uri.Segments.Length - 1];
                //path = Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);
                path = System.IO.Path.Combine(ImageUtils.ImageDirectory, fileName);
                // path = System.IO.Path.Combine(App.ImageDirectory, fileName);

                if (!File.Exists(path))
                {
                    DownloadImage(uri, path);
                }
            }
            catch
            {
                if (!File.Exists(path))
                {
                    GetImage(fileName, path);
                }
            }
            //  finally
            return new BitmapImage(new Uri(path));
        }

        private void GetImage(string image, string localFilePath)
        {
            Service1Client service = new Service1Client();
            byte[] imageArray = service.GetImage(image);

            var stream = new MemoryStream(imageArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(localFilePath);
        }

        private void DownloadImage(Uri uri, string localFilePath)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                using (Stream stream = webClient.OpenRead(uri))
                {
                    using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream))
                    {
                        stream.Flush();
                        stream.Close();
                        bitmap.Save(localFilePath);
                    }
                }
            }
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    ////https://blog.csainty.com/2009/12/wpf-multibinding-and.html
    //public sealed class ImageNameConverter : IMultiValueConverter //IValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        //public object Convert(object value, Type targetType,
    //        //                  object parameter, CultureInfo culture)

    //        // return String.Format("{0} {1}", values[0], values[1]);
    //        if (values[0] == null || values[1] == null ||
    //                !(values[0] is ImageList))
    //            return null;

    //        //   string fileName = (string)value;
    //        //   string fileName = ((ImageList)values[0])[(int)values[1]].ImgName;
    //        ImageList ImageList = ((ImageList)values[0]);
    //        if (ImageList.Count == 0)
    //        {
    //            return null;
    //        }
    //        string fileName = ImageList[(int)values[1]].Img;
    //        return fileName;
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //}
}