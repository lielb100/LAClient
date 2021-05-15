using ServiceReference1;
using System;

public partial class UserFullPageProfile : System.Web.UI.UserControl
{
    private string topimg;
    private ServiceReference1.User someUser;
    private string val = "";
    private string inte = "";
    private Service1Client sc = new Service1Client();

    public ServiceReference1.User SomeUser { get => someUser; set => someUser = value; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (SomeUser != (ServiceReference1.User)Session["LoggedIn"])
        {
            this.Button1.Text = sc.CheckFollowState((User)Session["LoggedIn"], SomeUser);
            this.Button1.Visible = true;
        }
        else
        {
            this.Button1.Visible = false;
        }
        if (someUser.Images[0] != null)
            topimg = SomeUser.Images[0].ToString();
        InterestList lisint = SomeUser.Interests;
        ValueList lisval = SomeUser.Values;
        int numint = (lisint.Count <= 10) ? lisint.Count : 10;
        int numval = (lisval.Count <= 10) ? lisval.Count : 10;

        for (int i = 0; i < numint; i++)
        {
            inte += lisint[i].InterestName + ", ";
        }

        inte = inte.Remove(inte.Length - 2, 2);
        inte += ".";

        for (int i = 0; i < numval; i++)
        {
            val += lisval[i].ValueName + ", ";
        }

        val = val.Remove(val.Length - 2, 2);
        val += ".";
        ProImage.ImageUrl = topimg;
        NameLabel.Text = SomeUser.FullName;
        InfoLabel.Text = SomeUser.Info;
        AgeLabel.Text = SomeUser.Age.ToString();
        SexLable.Text = SomeUser.Sex.GenName;
        InteLabel.Text = inte;
        ValLabel.Text = val;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        sc.Friend((ServiceReference1.User)Session["LoggedIn"], SomeUser);
    }
}