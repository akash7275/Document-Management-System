using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALHelper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class MakeTemplate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["LOGIN"]) == 0)
        {
            Response.Redirect("UsersLogin.aspx");
        }
        lblCategory.Visible = false;
        txtCategory.Visible = false;
    
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        Template objTemplate = new Template();
        Document objDocument = new Document();
        Category objCategory = new Category();
        ManageMakeTemplate objManageMakeTemplate = new ManageMakeTemplate();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        if (ddlCategory.SelectedValue != "0")
        {
            objCategory.Name = ddlCategory.SelectedItem.Text;

        }
        else
        {
            objCategory.Name = txtCategory.Text;

            string checkCatQuery = "SELECT * from Category where Name=@Name";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(checkCatQuery, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name", objCategory.Name);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                lblCategoryAlreadyExist.Text = "Category Already Exist";
            }
            else
            {

                string insertCatQuery = "INSERT into Category (Name)values(@Name)";
                SqlConnection conCat = new SqlConnection(cs);
                SqlCommand cmdCat = new SqlCommand(insertCatQuery, conCat);
                conCat.Open();
                cmdCat.Parameters.AddWithValue("@Name", objCategory.Name);
                cmdCat.ExecuteNonQuery();
            }
        }
        objTemplate.Subject = txtSubject.Text;
        objTemplate.Header = txtHeader.Text;
        objTemplate.Body = txtBody.Text;
        objTemplate.leftFooter = txtFooterLeft.Text;
        objTemplate.rightFooter = txtFooterRight.Text;

        objDocument.Subject=txtSubject.Text;
        objDocument.Body = txtBody.Text;
     
        bool status = objManageMakeTemplate.CreateTemplate(objCategory, objTemplate,objDocument);

        if (status == true)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Template Created'); window.location='" + Request.ApplicationPath + "DMSHomePage.aspx';", true);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Unable to create template'); window.location='" + Request.ApplicationPath + "DMSHomePage.aspx';", true);
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue == "0")
        {
            lblCategory.Visible = true;
            txtCategory.Visible = true;
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
}