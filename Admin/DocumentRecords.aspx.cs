using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DocumentRecords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Convert.ToInt32(Session["LOGIN"]) == 0)
        {
            Response.Redirect("../UsersLogin.aspx");
        }


        ManageMakeDocument objManageMakeDocument = new ManageMakeDocument();
        gridViewDocuments.DataSource = objManageMakeDocument.GetAllDocument();
        gridViewDocuments.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ManageMakeDocument objManageMakeDocument = new ManageMakeDocument();
        Button btn = (Button)sender;
        int Id = (Convert.ToInt32(btn.CommandArgument));
        ManageMakeDocument.DeleteDocument(Id);
        gridViewDocuments.DataSource = objManageMakeDocument.GetAllDocument();
        gridViewDocuments.DataBind();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int Id = (Convert.ToInt32(btn.CommandArgument));

        Session["printDocId"] = Id;
        Response.Redirect("../PrintDocument.aspx");
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
    protected void btnview_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int Id = (Convert.ToInt32(btn.CommandArgument));
        Session["docId"] = Id;
        
         
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        string retrieveImage = "SELECT * from Document where Id=@Id";
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand(retrieveImage, con);
        con.Open();
        cmd.Parameters.AddWithValue("@Id", Id);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {

            if (rd[5] == DBNull.Value)
            {
                Response.Write("<script>alert(\" No Document Uploaded \");</script>");
                
            }
            else
            {
                Session["docId"] = Id;
                Response.Redirect("ViewSignedDocument.aspx");
            }
        }
    }
  
   
   
}

