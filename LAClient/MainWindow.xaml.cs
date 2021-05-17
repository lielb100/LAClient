using System.Windows;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MyFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Content is MainPage)
            {
                this.Width = 1000;
                this.Height = 600;
            }
            else
            {
                this.Width = 800;
                this.Height = 450;
            }
        }
    }
}