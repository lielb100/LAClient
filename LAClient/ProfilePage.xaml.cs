using LAClient.ServiceReference1;
using System.Windows;
using System.Windows.Controls;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        //private ImageList imageList;
        //private int imgNum;
        //private List<bool> isUploadImg = new List<bool>();

        //public int ImgNum { get => imgNum; set => imgNum = value; } // needed for binding
        //public ImageList ImageList { get => imageList; set => imageList = value; }
        private Service1Client sr;

        private PreferenceList plist;
        private SexList slist;
        private AreaCodeList alist;

        //public ProfilePage(User user)
        //{
        //    InitializeComponent();
        //    this.s = user;
        //    slist = sr.GetAllSexes();
        //    this.SexBox.ItemsSource = slist;
        //    plist = sr.GetAllPreferences();
        //    this.PreferenceBox.ItemsSource = plist;
        //    this.s.Sex = (this.slist.Find(c => c.ID == s.Sex.ID));

        //    this.s.Preference = (this.plist.Find(c => c.ID == s.Preference.ID));

        //    this.DataContext = new
        //    {
        //        theUser = user,
        //        theImage = this.Filename,
        //    };

        //}
        private UserImageDC xx;

        public ProfilePage()
        {
            InitializeComponent();
            sr = new Service1Client();
            xx = new UserImageDC { TheImage = MainPage.CurrentUser.Image, TheUser = MainPage.CurrentUser };
            slist = sr.GetAllSexes();
            SexBox.ItemsSource = slist;
            plist = sr.GetAllPreferences();
            PreferenceBox.ItemsSource = plist;
            alist = sr.GetAllAreaCodes();
            AreaCodeBox.ItemsSource = alist;
            this.DataContext = xx;
            SexBox.SelectedItem = xx.TheUser.Sex;
            PreferenceBox.SelectedItem = xx.TheUser.Preference;
        }

        //xx.PropertyChanged += Xx_PropertyChanged

        //private void Xx_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //}

        private void forceRefresh()
        {
            this.DataContext = null;
            this.DataContext = xx;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageUtils.SendImage(xx.TheImage);
            xx.TheUser.Image = this.xx.TheImage;
            xx.TheUser.Sex = SexBox.SelectedItem as Sex;
            xx.TheUser.Preference = PreferenceBox.SelectedItem as Preference;

            if (sr.UpdateUser(xx.TheUser) != null)
            {
                MainPage.CurrentUser = xx.TheUser;
                forceRefresh();
            }
            else 
            {
                MessageBox.Show("Can't Update yet"); 
            }
        }

        //private void UploadImage_Click(object sender, RoutedEventArgs e)
        //{
        //    string filename = ImageUtils.UploadImage_Dlg();

        //    if (filename != null)  //ok
        //    {
        //        isUploadImg.Add(true);
        //        ImageUtils.SendImage(filename);

        //        this.imageList.Add(new LAClient.ServiceReference1.Image() { Img = filename });
        //        ImgNum = this.imageList.Count - 1;
        //        forceRefresh();
        //    }
        //}
        //private void PrevImage_Click(object sender, RoutedEventArgs e)
        //{
        //    ImgNum--;
        //    if (ImgNum < 0) ImgNum = this.ImageList.Count - 1;
        //    forceRefresh();
        //}

        //private void NextImage_Click(object sender, RoutedEventArgs e)
        //{
        //    ImgNum++;
        //    if (ImgNum > this.ImageList.Count - 1) ImgNum = 0;
        //    forceRefresh();
        //}

        //private void RemoveImg_OnClick(object sender, RoutedEventArgs e)
        //{
        //    this.ImageList.RemoveAt(ImgNum);
        //    //PicNum = Math.Max(home.PictureList.Count - 1, PicNum--);
        //    forceRefresh();
        //    PrevImage_Click(null, null);
        //}
        //private void SetProfile_onClick(object sender, RoutedEventArgs e)
        //{
        //    LAClient.ServiceReference1.Image i = this.ImageList[ImgNum];
        //    this.ImageList.RemoveAt(ImgNum);
        //    this.ImageList.Insert(0,i);
        //    sr.SetImageAsProfile(i, s);
        //    forceRefresh();
        //}
        private void SexBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void PreBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string newFile = ImageUtils.UploadImage_Dlg();
            if (newFile != null)
            {
                //this.ServerImage.Visibility = Visibility.Hidden;
                //this.NewImage.Visibility = Visibility.Visible;
                xx.TheImage = newFile;
            }

            //Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            //Nullable<bool> result = dlg.ShowDialog();
            //if (result == true)
            //{
            //    this.Filename = dlg.FileName;
            //    this.ImgArray = System.IO.File.ReadAllBytes(this.Filename);
            //}
        }
    }
}