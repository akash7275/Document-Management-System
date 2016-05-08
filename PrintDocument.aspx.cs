using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrintDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int documentId = Convert.ToInt32(Session["printDocId"]);
            ManagePrintDocument objManagePrintDocument = new ManagePrintDocument();
            int templateId = objManagePrintDocument.GetTemplateId(documentId);

            List<PrintData> lstPrintData = new List<PrintData>();

            lstPrintData = objManagePrintDocument.GetPrintData(templateId, documentId);

            for (int i = 0; i < lstPrintData.Count; i++)
            {

                lblHeader.Text = lstPrintData[i].Header;
                lblSubject.Text = lstPrintData[i].Subject;
                lblBody.Text = lstPrintData[i].Body.Replace("\r\n", "<br />");
                lblFooterLeft.Text = lstPrintData[i].leftFooter.Replace("\r\n", "<br />");
                lblFooterRight.Text = lstPrintData[i].rightFooter.Replace("\r\n", "<br />");
            }
        }
        catch (Exception ex) { }
       
    }
}
