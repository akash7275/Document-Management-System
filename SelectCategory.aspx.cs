using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectTemplate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Convert.ToInt32(Session["LOGIN"]) == 0)
        {
            Response.Redirect("UsersLogin.aspx");
        }


        ManageMakeTemplate objManageMakeTemplate = new ManageMakeTemplate();
        DataSet ds=objManageMakeTemplate.GetDataTemplate();
        rptSelectCategory.DataSource = ds;
        rptSelectCategory.DataBind();
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["LOGIN"] = 0;
        Response.Redirect("UsersLogin.aspx");
    }
    protected void btnNavLogout_Click(object sender, EventArgs e)
    {
        Session["LOGIN"] = 0;
        Response.Redirect("UsersLogin.aspx");
    }
    protected void btnDocName_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int Id = (Convert.ToInt32(btn.CommandArgument));
        Session["CategoryId"] = Id;
        Response.Redirect("SelectTemplate.aspx");
    }
}