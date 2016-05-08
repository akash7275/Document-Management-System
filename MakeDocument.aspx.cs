using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.IO;

public partial class MakeDocument : System.Web.UI.Page
{
    Template objTemplate = new Template();
    Document objDocument = new Document();
    ManageMakeDocument objManageMakeDocument = new ManageMakeDocument();
    StatusMakeDocument objStatusMakeDocument = new StatusMakeDocument(); 
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Convert.ToInt32(Session["LOGIN"]) == 0)
        {
            Response.Redirect("UsersLogin.aspx");
        }


        int TemplateId = Convert.ToInt32(Session["TemplateId"]);
        objTemplate.Id = TemplateId;
        objTemplate = objManageMakeDocument.RetreiveTemplate(objTemplate);

        if (!IsPostBack)
        {
            txtHeader.Text = objTemplate.Header;
            txtSubject.Text = objTemplate.Subject;
            txtBody.Text = objTemplate.Body;
            txtFooterLeft.Text = objTemplate.leftFooter;
            txtFooterRight.Text = objTemplate.rightFooter;
        }
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int compHeader, compFooterLeft,compFooterRight;
        objDocument.TemplateID = objTemplate.Id;
        compHeader = String.Compare(objTemplate.Header, txtHeader.Text);
        compFooterLeft = String.Compare(objTemplate.leftFooter, txtFooterLeft.Text);
        compFooterRight = String.Compare(objTemplate.rightFooter, txtFooterRight.Text);

        if (compHeader == 0 && compFooterLeft == 0 && compFooterRight==0)
        {
         
            {
                objDocument.Subject = txtSubject.Text;
                objDocument.Body = txtBody.Text.Replace("\r\n", "<br />");
                objStatusMakeDocument = objManageMakeDocument.MakeNewDocument(objDocument);
                if (objStatusMakeDocument.saved == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect","alert('Document Created Successfully'); window.location='" +Request.ApplicationPath + "DMSHomePage.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Unable to create document'); window.location='" + Request.ApplicationPath + "DMSHomePage.aspx';", true);
                }
            }
           
        }
        else
        {
            Template objNewTemplate = new Template();
            Document objNewDocument = new Document();
            objNewTemplate.CategoryId = objTemplate.CategoryId;
            objNewTemplate.Header = txtHeader.Text;
            objNewTemplate.Subject = txtSubject.Text;
            objNewTemplate.Body = txtBody.Text;
            objNewTemplate.leftFooter = txtFooterLeft.Text;
            objNewTemplate.rightFooter = txtFooterRight.Text;

            objNewDocument.Subject = objNewTemplate.Subject;
            objNewDocument.Body = objNewTemplate.Body.Replace("\r\n", "<br />");
            objStatusMakeDocument=objManageMakeDocument.MakeNewTemplateDocument(objNewTemplate, objNewDocument);

            if (objStatusMakeDocument.saved == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Document Created Successfully'); window.location='" + Request.ApplicationPath + "DMSHomePage.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Unable to create document'); window.location='" + Request.ApplicationPath + "DMSHomePage.aspx';", true);
            }

        }

      
    }




    
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        int compHeader, compFooterLeft, compFooterRight;
        objDocument.TemplateID = objTemplate.Id;
        compHeader = String.Compare(objTemplate.Header, txtHeader.Text);
        compFooterLeft = String.Compare(objTemplate.leftFooter, txtFooterLeft.Text);
        compFooterRight = String.Compare(objTemplate.rightFooter, txtFooterRight.Text);

        if (compHeader == 0 && compFooterLeft == 0 && compFooterRight == 0)
        {
            objDocument.Subject = txtSubject.Text;
            objDocument.Body = txtBody.Text;
            objStatusMakeDocument = objManageMakeDocument.MakeNewDocument(objDocument);

            if (objStatusMakeDocument.saved == true)
            {
                Session["printDocId"] = objStatusMakeDocument.id;
                Response.Redirect("PrintDocument.aspx");
            }
            else
            { }
        }
        else
        {
            Template objNewTemplate = new Template();
            Document objNewDocument = new Document();
            objNewTemplate.CategoryId = objTemplate.CategoryId;
            objNewTemplate.Header = txtHeader.Text;
            objNewTemplate.Subject = txtSubject.Text;
            objNewTemplate.Body = txtBody.Text;
            objNewTemplate.leftFooter = txtFooterLeft.Text;
            objNewTemplate.rightFooter = txtFooterRight.Text;


            objNewDocument.Subject = objNewTemplate.Subject;
            objNewDocument.Body = objNewTemplate.Body;
            objStatusMakeDocument=objManageMakeDocument.MakeNewTemplateDocument(objNewTemplate, objNewDocument);
            if (objStatusMakeDocument.saved == true)
            {
                Session["printDocId"] = objStatusMakeDocument.id;
                Response.Redirect("window.open('PrintDocument.aspx')");
            }
            else
            { }
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