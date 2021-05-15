public partial class ProfilePage : System.Web.UI.Page
{
    private Service1Client sc = new Service1Client();
    private User us1;

    //public ProfilePage() { us1 = (User)Session["LoggedIn"]; }
    //public ProfilePage(User us2) { us1 = us2; }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UserFullPageProfile1.SomeUser = (User)Session["ProfileUser"];
    }

    private void InitializeComponent()
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendsPage.aspx");
    }
}