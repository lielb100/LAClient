using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAClient.SRtoHost;
namespace LAClient
{
    class Profile
    {
        private int id;
        private LAClient.SRtoHost.ImageList pimages;
        private LAClient.SRtoHost.Image profilepic;
        private string name;
        private int age;
        private bool ver;
        private string info;

        public Profile(User user)
        {
            LAClient.SRtoHost.ImageList imgs = new LAClient.SRtoHost.ImageList();
            LAClient.SRtoHost.ImageList userimgs = user.Images;
            foreach (LAClient.SRtoHost.Image i in imgs)
            {
                if ((i.Type == 2) && (i.Userr == user.ID))
                    imgs.Add(i);
            }

            this.pimages = imgs;
            this.profilepic = userimgs.Find(item => (item.Type == 1) && (item.Userr == user.ID));
            this.name = user.Fname + " " + user.Lname;
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(user.BirthDate.ToString("yyyyMMdd"));
            this.age = (now - dob) / 10000;
            this.ver = user.IsVer;
            this.info = user.Info;
        }

        public LAClient.SRtoHost.ImageList Pimages { get => pimages; set => pimages = value; }
        public LAClient.SRtoHost.Image Profilepic { get => profilepic; set => profilepic = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public bool Ver { get => ver; set => ver = value; }
        public string Info { get => info; set => info = value; }

    }
    
    }

