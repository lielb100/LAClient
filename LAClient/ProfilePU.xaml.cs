using LAClient.ServiceReference1;
using System.Windows;
using System.Windows.Controls;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for ProfilePU.xaml
    /// </summary>
    public partial class ProfilePU : Window
    {
        private UserImageDC xx;
        private Service1Client sr;
        private PreferenceList plist;
        private SexList slist;
        private AreaCodeList alist;
        private Admin admin;


        public ProfilePU()
        {
            InitializeComponent();
        }

        public ProfilePU(User UpdateUser, Admin father) : this()
        {
            admin = father;
            sr = new Service1Client();
            xx = new UserImageDC { TheImage = UpdateUser.Image, TheUser = UpdateUser };

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

        private void forceRefresh()
        {
            this.DataContext = null;
            this.DataContext = xx;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageUtils.SendImage(xx.TheImage);
            xx.TheUser.Image = xx.TheImage;
            xx.TheUser.Sex = SexBox.SelectedItem as Sex;
            xx.TheUser.Preference = PreferenceBox.SelectedItem as Preference;
            if (sr.UpdateUser(xx.TheUser) != null)
            {
                this.Close();
                admin.ForceRefresh();
            }
            else
            {
                MessageBox.Show("Can't Update yet");
            }
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
    }
}