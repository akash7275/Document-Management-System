using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["LOGIN"]) == 0)
        {
            Response.Redirect("UsersLogin.aspx");
        }


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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ManageMakeDocument objManageMakeDocument = new ManageMakeDocument();
        try
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string insertQuery = "insert into UserLogin (UserName,Password) values (@UserName,@Password)";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            con.Open();
            cmd.Parameters.AddWithValue("@UserName", txtAdminName.Text);
            cmd.Parameters.AddWithValue("@Password", txtAdminPassword.Text);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Admin Registered'); window.location='" + Request.ApplicationPath + "DMSHomePage.aspx';", true);

           
          

        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Unable to register admin'); window.location='" + Request.ApplicationPath + "DMSHomePage.aspx';", true);
           

        }
    }

    
}