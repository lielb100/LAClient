using LAClient.ServiceReference1;
using System.ComponentModel;

namespace LAClient
{
    public class UserImageDC : INotifyPropertyChanged
    {
        private User theUser;
        private string theImage;

        public User TheUser
        {
            get { return theUser; }
            set
            {
                if (theUser != value)
                {
                    theUser = value;
                    OnPropertyChanged("TheUser");
                }
            }
        }

        public string TheImage
        {
            get { return theImage; }
            set
            {
                if (theImage != value)
                {
                    theImage = value;
                    OnPropertyChanged("TheImage");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}