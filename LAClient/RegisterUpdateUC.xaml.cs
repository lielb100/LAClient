using LAClient.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for RegisterUpdateUC.xaml
    /// </summary>
    public partial class RegisterUpdateUC : UserControl
    {
        #region Register

        #region Helpers

        private string ValidateRegister()
        {
            string msg = string.Empty;
            if (!ValidatorHelper.IsValidEmail(dc.TheUser.Email)) msg += "Email Is Not Valid\n";
            if (!ValidatorHelper.IsValidPassword(dc.TheUser.Password)) msg += "Password Is Not Valid\n";
            if (!ValidatorHelper.IsValidPhone(dc.TheUser.Phone)) msg += "Phone Number Is Not Valid\n";
            if (dc.TheUser.Fname == null || dc.TheUser.Fname.Length <= 1 || ValidatorHelper.HasComma(dc.TheUser.Fname)) msg += "First Name Is Not Valid!\n";
            if (dc.TheUser.Lname == null || dc.TheUser.Lname.Length <= 1 || ValidatorHelper.HasComma(dc.TheUser.Lname)) msg += "Last Name Is Not Valid!\n";
            if (dc.TheUser.Info == null || dc.TheUser.Info.Length <= 1 || ValidatorHelper.HasComma(dc.TheUser.Info)) msg += "Info Is Not Valid!\n";
            if (dc.TheUser.Sex == null) msg += "Sex Is Not Valid!\n";
            if (dc.TheUser.Preference == null) msg += "Preference Is Not Valid!\n";
            if (dc.TheUser.AreaCode == null) msg += "Area Code Is Not Valid!\n";
            if (dc.TheUser.Image == null || dc.TheUser.Image.Length <= 1) msg += "Image Is Not Valid";

            return msg;
        }

        #endregion Helpers

        #region RegisterPage

        /// <summary>
        /// new instance of Register Page
        /// </summary>
        /// <param name="nav"></param>
        public RegisterUpdateUC(NavigationService nav) : this()
        {
            FinishBttn.Click += FinishBttn_Click_RegisterPage;
            this.nav = nav;
            FinishBttn.Content = "Create new account";
            H1.Text = "Register";
            Return.Visibility = Visibility.Visible;
        }

        private void FinishBttn_Click_RegisterPage(object sender, RoutedEventArgs e)
        {
            PopulateUser();
            string msg = ValidateRegister();
            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                return;
            }
            if (sc.RegiserUser(dc.TheUser) != null)
            {
                MessageBox.Show("Successful!", "Welcome!");
                ImageUtils.SendImage(dc.TheImage);
                nav.Navigate(new MainPage(dc.TheUser));
            }
            else
            {
                MessageBox.Show("Failed For Some Reason");
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            nav.Navigate(new LoginPage());
        }

        #endregion RegisterPage

        #region RegisterPU

        /// <summary>
        /// new instance of Register Pop Up
        /// </summary>
        /// <param name="activateChange"></param>
        public RegisterUpdateUC(EventHandler activateChange) : this()
        {
            FinishBttn.Click += FinishBttn_Click_RegisterPU;
            FinishBttn.Content = "Insert";
            this.activateChange = activateChange;
            H1.Text = "Insert New User";
        }

        private void FinishBttn_Click_RegisterPU(object sender, RoutedEventArgs e)
        {
            PopulateUser();
            string msg = ValidateRegister();
            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                return;
            }
            if (sc.RegiserUser(dc.TheUser) != null)
            {
                ImageUtils.SendImage(dc.TheImage);
                MessageBox.Show("Successful!", $"User {dc.TheUser.FullName} was created!");
                activateChange(this, null);
            }
            else
            {
                MessageBox.Show("Failed For Some Reason");
            }
            activateChange(this, null);
        }

        #endregion RegisterPU

        #endregion Register

        #region Profile

        #region Helpers

        private void ChangeLayoutForProfile()
        {
            EmailBlock.Visibility = Visibility.Collapsed;
            PasswordBlock.Visibility = Visibility.Collapsed;
            EmailBox.Visibility = Visibility.Collapsed;
            PasswordBox.Visibility = Visibility.Collapsed;
            DateOfBirthBlock.Visibility = Visibility.Collapsed;
            DateOfBirthPicker.Visibility = Visibility.Collapsed;
            DOBRow.Height = new GridLength(0);
            PasswordRow.Height = new GridLength(0);
            EmailRow.Height = new GridLength(0);
            ImageBttn.SetValue(Grid.RowProperty, 6);
        }

        private string ValidateProfile()
        {
            string msg = string.Empty;
            if (!ValidatorHelper.IsValidPhone(dc.TheUser.Phone)) msg += "Phone Number Is Not Valid\n";
            if (dc.TheUser.Fname == null || dc.TheUser.Fname.Length <= 1 || ValidatorHelper.HasComma(dc.TheUser.Fname)) msg += "First Name Is Not Valid!\n";
            if (dc.TheUser.Lname == null || dc.TheUser.Lname.Length <= 1 || ValidatorHelper.HasComma(dc.TheUser.Lname)) msg += "Last Name Is Not Valid!\n";
            if (dc.TheUser.Info == null || dc.TheUser.Info.Length <= 1 || ValidatorHelper.HasComma(dc.TheUser.Info)) msg += "Info Is Not Valid!\n";
            if (dc.TheUser.Sex == null) msg += "Sex Is Not Valid!\n";
            if (dc.TheUser.Preference == null) msg += "Preference Is Not Valid!\n";
            if (dc.TheUser.AreaCode == null) msg += "Area Code Is Not Valid!\n";

            return msg;
        }

        #endregion Helpers

        #region ProfilePU

        /// <summary>
        /// new instance of Profile Pop Up
        /// </summary>
        /// <param name="UpdateUser"></param>
        /// <param name="activateChange"></param>
        public RegisterUpdateUC(User UpdateUser, EventHandler activateChange) : this()
        {
            FinishBttn.Click += FinishBttn_Click_ProfilePU;
            FinishBttn.Content = "Update";
            this.activateChange = activateChange;
            dc.TheUser = UpdateUser;
            dc.TheImage = UpdateUser.Image;
            H1.Text = $"Edit {dc.TheUser.FullName}";
            dc.TheUser.Sex = slist.Find(item => item.ID == dc.TheUser.Sex.ID);
            dc.TheUser.AreaCode = alist.Find(item => item.ID == dc.TheUser.AreaCode.ID);
            dc.TheUser.Preference = plist.Find(item => item.ID == dc.TheUser.Preference.ID);
            ChangeLayoutForProfile();
        }

        private void FinishBttn_Click_ProfilePU(object sender, RoutedEventArgs e)
        {
            PopulateUser();
            string msg = ValidateProfile();
            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                return;
            }

            if (sc.UpdateUser(dc.TheUser) != null)
            {
                ImageUtils.SendImage(dc.TheImage);
                activateChange(this, null);
            }
            else
            {
                MessageBox.Show("Can't Update yet");
            }
        }

        #endregion ProfilePU

        #region ProfilePage

        /// <summary>
        /// new instance of Profile Page
        /// </summary>
        /// <param name="UpdateUser"></param>
        public RegisterUpdateUC(User UpdateUser) : this()
        {
            FinishBttn.Click += FinishBttn_Click_ProfilePage;
            FinishBttn.Content = "Update";

            dc.TheUser = UpdateUser;
            dc.TheImage = UpdateUser.Image;
            H1.Text = "Profile";
            dc.TheUser.Sex = slist.Find(item => item.ID == dc.TheUser.Sex.ID);
            dc.TheUser.AreaCode = alist.Find(item => item.ID == dc.TheUser.AreaCode.ID);
            dc.TheUser.Preference = plist.Find(item => item.ID == dc.TheUser.Preference.ID);
            ChangeLayoutForProfile();
        }

        private void FinishBttn_Click_ProfilePage(object sender, RoutedEventArgs e)
        {
            PopulateUser();
            string msg = ValidateProfile();
            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                return;
            }
            if (sc.UpdateUser(dc.TheUser) != null)
            {
                MainPage.CurrentUser = dc.TheUser;
                ImageUtils.SendImage(dc.TheImage);
                DataContext = null;
                DataContext = this;
            }
            else
            {
                MessageBox.Show("Can't Update yet ");
            }
        }

        #endregion ProfilePage

        #endregion Profile

        #region General

        private UserImageDC dc;
        private Service1Client sc;
        private PreferenceList plist;
        private SexList slist;
        private AreaCodeList alist;
        private NavigationService nav;

        private event EventHandler activateChange;

        private RegisterUpdateUC()
        {
            InitializeComponent();
            sc = new Service1Client();
            dc = new UserImageDC()
            {
                TheUser = new User(),
                TheImage = "",
            };
            slist = sc.GetAllSexes();
            SexBox.ItemsSource = slist;
            plist = sc.GetAllPreferences();
            PreferenceBox.ItemsSource = plist;
            alist = sc.GetAllAreaCodes();
            AreaCodeBox.ItemsSource = alist;

            this.DataContext = dc;
            DateOfBirthPicker.DisplayDateStart = DateTime.Now.AddYears(-18);
            DateOfBirthPicker.DisplayDateEnd = DateTime.Now.AddYears(-120);
        }

        private void PopulateUser()
        {
            dc.TheUser.Image = dc.TheImage;
            dc.TheUser.Sex = SexBox.SelectedItem as Sex;
            dc.TheUser.Preference = PreferenceBox.SelectedItem as Preference;
            dc.TheUser.Checked1 = true;
            dc.TheUser.DeviceID = "0";
            dc.TheUser.Ext_Id = "0";
            dc.TheUser.Ext_Type = "0";
            dc.TheUser.Seen = true;
            dc.TheUser.IsVer = true;
        }

        private void ImageBttn_Click(object sender, RoutedEventArgs e)
        {
            string newFile = ImageUtils.UploadImage_Dlg();
            if (newFile != null)
            {
                dc.TheImage = newFile;
            }
        }

        private void ServerImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var imagePopUp = new ImagePU(dc.TheImage);
            imagePopUp.ShowDialog();
        }
        #endregion General


    }
}