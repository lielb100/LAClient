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
namespace LAClient
{
    /// <summary>
    /// Interaction logic for VerAdmin.xaml
    /// </summary>
    public partial class VerAdmin : Page
    {
        Service1Client sr = new Service1Client();
        private ImageList imageList;
        private int imgNum;
        private List<bool> isUploadImg = new List<bool>();

        public int ImgNum { get => imgNum; set => imgNum = value; } // needed for binding
        public ImageList ImageList { get => imageList; set => imageList = value; }
        public VerAdmin(int i)
        {
         
            User user = Admin.Veruser;
            InitializeComponent();
            this.ImageList = sr.GetImagesNoVer(user);
            verimg.Source = new BitmapImage(new Uri(sr.GetVerByUser(user).Img));
            sp.Click += (sender, e) => Button_Click(i, sender, e);
            ntsp.Click += (sender, e) => Button_Click1(i, sender, e);
            gttp.Click += (sender, e) => Button_Click2(sender, e);

        }
        private void forceRefresh()
        {
            this.DataContext = null;
            this.DataContext = this;
        }
        private void PrevImage_Click(object sender, RoutedEventArgs e)
        {
            ImgNum--;
            if (ImgNum < 0) ImgNum = this.ImageList.Count - 1;
            forceRefresh();
        }

        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            ImgNum++;
            if (ImgNum > this.ImageList.Count - 1) ImgNum = 0;
            forceRefresh();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Home.Frame.Navigate(Admin.Veruser);
        }

        private void Button_Click(int i ,object sender, RoutedEventArgs e)
        {
            User us1 = Admin.Veruser;
            sr.VerifyByUser(us1);
            sr.CheckUser(us1);
            if (i == 1)
            Home.Frame.Navigate(new Admin());
            Home.Frame.Navigate(new NonVer());
        }

        private void Button_Click1(int i ,object sender, RoutedEventArgs e)
        {
            sr.CheckUser(Admin.Veruser);
            if(Home.Frame.CanGoBack)
            Home.Frame.GoBack();
        }

        private void ntsp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
