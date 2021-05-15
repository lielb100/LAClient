using ServiceReference1;
using System;

public partial class LoginTemp : System.Web.UI.Page
{
    private Service1Client sc = new Service1Client();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["RememberUserName"] != null && Request.Cookies["RememberPassword"] != null)
            {
                UserName.Text = Response.Cookies["UserName"].Value;
                Password.Attributes["value"] = Response.Cookies["Password"].Value;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ServiceReference1.User LoggedInUser = new ServiceReference1.User();
        int num = 0;
        LoggedInUser = sc.CheckLogin(this.UserName.Text, this.Password.Text);

        if (LoggedInUser != null && (int)Session["LoginTries"] < 5)
        {
            Session["LoggedIn"] = LoggedInUser;
            if (this.rememberme.Checked)
            {
                Response.Cookies["RememberUserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["RememberPassword"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["RememberUserName"].Value = this.UserName.Text.Trim();
                Response.Cookies["RememberPassword"].Value = this.Password.Text.Trim();
            }
            else
            {
                Response.Cookies["RememberUserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["RememberPassword"].Expires = DateTime.Now.AddDays(-1);
            }

            Session["ProfileUser"] = (User)Session["LoggedIn"];
            Response.Redirect("ProfilePage.aspx");
        }
        else
        {
            num = 5 - (int)Session["LoginTries"];
            Session["LoginTries"] = (int)Session["loginTries"] + 1;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Email or password is incorrect.\n You have " + num + " tries left" + "');", true);
        }
    }
}