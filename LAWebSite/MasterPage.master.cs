using System;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected string menu = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoggedIn"] is null)
        {
            //ListView list = new();
            //list.
            menu += "<li><a href = 'LoginPage.aspx'> Login</a></li>";
            menu += "<li><a href = 'RegisterPage.aspx'> Register</a></li>";
        }
        else
        {
            menu += "<li><a href = 'FriendsPage.aspx'> Home</a></li>";
            menu += "<li><a href = 'upd.aspx'> Update</a></li>";
            menu += "<li><a href = 'topsh.aspx'> Add A Show</a></li>";
            menu += "<li><a href = 'survey.aspx'> Survey</a></li>";
            menu += "<li style='float:right'><a class='active'  href = 'logout.aspx'> Logout</a></li>";
        }
    }
}