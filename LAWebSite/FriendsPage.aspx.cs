public partial class FriendsPage : System.Web.UI.Page
{
    private Service1Client sc = new Service1Client();

    protected void Page_Load(object sender, EventArgs e)
    {
        var lis = sc.GetAllRequestedByUser((ServiceReference1.User)Session["LoggedIn"]);
        foreach (ServiceReference1.User u in lis)
        {
            if (sc.CheckFollowState((ServiceReference1.User)Session["LoggedIn"], u) == "Approve")
            {
                SmallUserProfile small = new SmallUserProfile
                {
                    SomeUser = u
                };
                small = LoadControl("http://localhost:54063/SmallUserProfile.ascx") as SmallUserProfile;
                this.Panel1.Controls.Add(small);
            }
            else
            {
                SmallUserProfile small = new SmallUserProfile
                {
                    SomeUser = u
                };
                small = LoadControl("http://localhost:54063/SmallUserProfile.ascx") as SmallUserProfile;
                this.Panel2.Controls.Add(small);
            }
        }
    }
}