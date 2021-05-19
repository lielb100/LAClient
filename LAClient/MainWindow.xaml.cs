using System;
using System.Windows;
using System.Windows.Controls;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Frame mainFrame;
        public static Frame MainFrame { get => mainFrame; set => mainFrame = value; }

        public MainWindow()
        {
            InitializeComponent();
            mainFrame = new Frame { NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden, 
                Source = new Uri("LoginPage.xaml", UriKind.Relative)};
            mainFrame.Navigated += MainFrame_Navigated;
            this.gridy.Children.Add(mainFrame);

        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
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