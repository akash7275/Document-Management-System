using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Convert.ToInt32(Session["LOGIN"]) == 0)
        {
            Response.Redirect("UsersLogin.aspx");
        }


        int Id = Convert.ToInt32(Session["CategoryId"]);
        ManageMakeDocument objManageMakeDocument = new ManageMakeDocument();
        DataSet ds = objManageMakeDocument.GetDataTemplate(Id);
        rptSelectDocument.DataSource = ds;
        rptSelectDocument.DataBind();
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
        int TemplateId = (Convert.ToInt32(btn.CommandArgument));
        Session["TemplateId"] = TemplateId;
        Response.Redirect("MakeDocument.aspx");
    }
}