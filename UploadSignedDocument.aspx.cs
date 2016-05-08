using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SNP.Enums;

public partial class UploadSignedDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Convert.ToInt32(Session["LOGIN"]) == 0)
        {
            Response.Redirect("UsersLogin.aspx");
        }

        labReplace.Visible = false;
        btnReplace.Visible = false;


        if (Session["uploadDocId"] != null)
        { 
          txtDocumentId.Text=(Convert.ToInt32(Session["uploadDocId"])).ToString();
        }

    }

    ManageMakeDocument objManageMakeDocument = new ManageMakeDocument();
    Document objDocument = new Document();

    protected void btnUploadDocument_Click(object sender, EventArgs e)
    {
        objDocument.Id = Convert.ToInt32(txtDocumentId.Text);
        objDocument.SignedDocument = fuSignedDocument.FileName;
        UploadStatus checkStatus = objManageMakeDocument.CheckSignedDocument(objDocument);
        if (checkStatus == UploadStatus.NotExist)
        {
            if (fuSignedDocument.HasFile)
            {
               

                fuSignedDocument.SaveAs(MapPath("~/SignedDocument/" + fuSignedDocument.FileName));
            }
            else
            { labUploadStatus.Text = "No file received."; }

            bool uploadStatus = objManageMakeDocument.UploadSignedDocument(objDocument);

            if (uploadStatus == true)
            {
                labUploadStatus.Text = "Sucessfully Uploaded";
            }

        }
        else if (checkStatus == UploadStatus.AlreadyExist)
        {
            labReplace.Visible = true;
            labReplace.Text = "Signed Document for provided Document Id already exist want to replace?";
            btnReplace.Visible = true;

        }

        else if (checkStatus == UploadStatus.InvalidDocId)
        {
            labUploadStatus.Text = "Invalid Document Id try with a valid Document Id";
        }

        Session["Id"] = objDocument.Id;
        Session["SignedDocument"] = objDocument.SignedDocument;

    }
    protected void btnReplace_Click(object sender, EventArgs e)
    {

        objDocument.Id = Convert.ToInt32(Session["Id"]);
        objDocument.SignedDocument = Session["SignedDocument"].ToString();

        bool uploadStatus = objManageMakeDocument.UploadSignedDocument(objDocument);

        if (uploadStatus == true)
        {
            //labUploadStatus.Text = "Sucessfully Uploaded";

            Response.Write("<script>alert(\" Your template has been created \");</script>");
            Response.Redirect("DMSHomePage.aspx");
        }

    }


  
    protected void ddlChooseDocument_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDocumentId.Text = ddlChooseDocument.SelectedValue;
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
