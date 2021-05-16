using LAClient.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
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
        private UserImageDC xx;

        public RegisterPage()
        {
            InitializeComponent();
            sr = new Service1Client();
            xx = new UserImageDC()
            {
                TheUser = new User(),
                TheImage = "",
            };
            slist = sr.GetAllSexes();
            SexBox.ItemsSource = slist;
            plist = sr.GetAllPreferences();
            PreferenceBox.ItemsSource = plist;
            alist = sr.GetAllAreaCodes();
            AreaCodeBox.ItemsSource = alist;

            this.DataContext = xx;
            SexBox.SelectedItem = xx.TheUser.Sex;
            PreferenceBox.SelectedItem = xx.TheUser.Preference;
            dp.DisplayDateEnd = DateTime.Now;
            dp.DisplayDateStart = DateTime.Now.AddYears(-120);

            this.DataContext = xx;
        }

        private void forceRefresh()
        {
            this.DataContext = null;
            this.DataContext = xx;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string msg = string.Empty;
            if (!ValidatorHelper.IsValidEmail(xx.TheUser.Email)) msg += "Email Is Not Valid\n";
            if (!ValidatorHelper.IsValidPassword(xx.TheUser.Password)) msg += "Password Is Not Valid\n";
            if (!ValidatorHelper.IsValidPhone(xx.TheUser.Phone)) msg += "Phone Number Is Not Valid";

            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                return;
            }
            ImageUtils.SendImage(xx.TheImage);
            xx.TheUser.Image = xx.TheImage;
            xx.TheUser.Sex = SexBox.SelectedItem as Sex;
            xx.TheUser.Preference = PreferenceBox.SelectedItem as Preference;

            sr.RegiserUser(xx.TheUser);
            var nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MainPage(xx.TheUser));
        }

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
                xx.TheImage = newFile;
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigation = NavigationService.GetNavigationService(this);
            if (navigation.CanGoBack) navigation.GoBack();
        }
    }
}