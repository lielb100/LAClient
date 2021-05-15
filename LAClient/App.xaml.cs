using System;
using System.Windows;

namespace LAClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string imageDirectory;
        public static string ImageDirectory { get => imageDirectory; set => imageDirectory = value; }

        static App()
        {
            imageDirectory = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/");
        }
    }
}