using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CategoryWise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Convert.ToInt32(Session["LOGIN"]) == 0)
        {
            Response.Redirect("../UsersLogin.aspx");
        }
       
        ManageMakeTemplate objManageMakeTemplate = new ManageMakeTemplate();
        DataSet ds = objManageMakeTemplate.GetDataTemplate();
        rptSelectCategory.DataSource = ds;
        rptSelectCategory.DataBind();
        gridViewDocuments.Visible = false;
    }

  
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ManageMakeDocument objManageMakeDocument = new ManageMakeDocument();
        Button btn = (Button)sender;
        int Id = (Convert.ToInt32(btn.CommandArgument));
        int categoryId=ManageMakeDocument.DeleteDocument(Id);
        gridViewDocuments.DataSource = objManageMakeDocument.GetDataDocument(categoryId);
        gridViewDocuments.DataBind();
        gridViewDocuments.Visible = true;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int Id = (Convert.ToInt32(btn.CommandArgument));

        Session["printDocId"] = Id;
        Response.Redirect("../PrintDocument.aspx");
    }
   

    public DateTime ConvertDate(byte time)
    {

        long longVar = Convert.ToInt64(time);
        DateTime dateTimeVar = new DateTime(1980, 1, 1).AddMilliseconds(longVar);
        return dateTimeVar;
    }
   
    protected void btnCategory_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Button btn = (Button)sender;
            int Id = (Convert.ToInt32(btn.CommandArgument));
            
            ManageMakeDocument objManageMakeDocument = new ManageMakeDocument();
            DataSet ds = objManageMakeDocument.GetDataDocument(Id);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert(\" No Document Created Under this category \");</script>");
                Id = Convert.ToInt32(Session["CategoryId"]);
                DataSet dss = objManageMakeDocument.GetDataDocument(Id);
                gridViewDocuments.DataSource = dss;
                gridViewDocuments.DataBind();
                gridViewDocuments.Visible = true;
            
            }
            else
            {
                Session["CategoryId"] = Id;
                gridViewDocuments.DataSource = ds;
                gridViewDocuments.DataBind();
                gridViewDocuments.Visible = true;
            }
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
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int Id = (Convert.ToInt32(btn.CommandArgument));

        Session["uploadDocId"] = Id;
        Response.Redirect("../UploadSignedDocument.aspx");
    }

    protected void btnSignedDocument_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int Id = (Convert.ToInt32(btn.CommandArgument));


    }
}