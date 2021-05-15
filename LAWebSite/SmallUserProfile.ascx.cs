using ServiceReference1;
using System;
using System.Linq;

public partial class SmallUserProfile : System.Web.UI.UserControl
{
    private Service1Client sc = new Service1Client();
    private ServiceReference1.User someUser;

    public ServiceReference1.User SomeUser { get => someUser; set => someUser = value; }

    protected void Page_Load(object sender, EventArgs e)
    {
        string flw = sc.CheckFollowState((ServiceReference1.User)Session["LoggedIn"], SomeUser);
        FollowButton.Text = flw;
        switch (flw)
        {
            case "Unfriend":
                FollowButton.BackColor = System.Drawing.Color.Red;
                FollowButton.ForeColor = System.Drawing.Color.White;
                break;

            case "Requested":
                FollowButton.BackColor = System.Drawing.Color.Black;
                FollowButton.ForeColor = System.Drawing.Color.White;
                break;

            case "Approve":
                FollowButton.BackColor = System.Drawing.Color.LightGreen;
                FollowButton.ForeColor = System.Drawing.Color.Black;
                break;

            case "Request":
                FollowButton.BackColor = System.Drawing.Color.White;
                FollowButton.ForeColor = System.Drawing.Color.Black;
                break;
        }
        this.agelabel.Text = SomeUser.Age.ToString();
        this.infolabel.Text = SomeUser.Info;
        this.namelabel.Text = SomeUser.FullName;
        this.Image1.ImageUrl = SomeUser.Images.ElementAt(0).Img;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        sc.Friend((ServiceReference1.User)Session["LoggedIn"], SomeUser);
    }
}