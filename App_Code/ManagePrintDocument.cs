using DALHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class ManagePrintDocument
{
    public List<PrintData> GetPrintData(int templateId, int documentId)
    {
        PrintData objPrintdata = new PrintData();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        DataSet ds;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            List<SqlParameter> lstGetData = new List<SqlParameter>();
            lstGetData.Add(new SqlParameter("@documentId", documentId));
            lstGetData.Add(new SqlParameter("@templateId", templateId));

            ds = objDDBDataHelper.GetDataSet("Select objTemplate.Header,objDocument.[Subject],objDocument.Body,objTemplate.LeftFooter,objTemplate.RightFooter  From  Template objTemplate,Document objDocument WHERE objDocument.Id=@documentId AND objTemplate.Id=@templateId", SQLTextType.Query, lstGetData);
            List<PrintData> lstPrintdata = new List<PrintData>();
            int i = 0;
            foreach (DataRow rows in ds.Tables[0].Rows)
            {

                objPrintdata.Header = ds.Tables[0].Rows[i][0].ToString();
                objPrintdata.Subject = ds.Tables[0].Rows[i][1].ToString();
                objPrintdata.Body = ds.Tables[0].Rows[i][2].ToString();
                objPrintdata.leftFooter = ds.Tables[0].Rows[i][3].ToString();
                objPrintdata.rightFooter = ds.Tables[0].Rows[i][4].ToString(); ;

                lstPrintdata.Add(objPrintdata);
                i++;
            }
            return lstPrintdata;
        }
    }

    public int GetTemplateId(int documentId)
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        string retrieveTemplateId = "SELECT TemplateId from Document where Id=@Id";
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand(retrieveTemplateId, con);
        con.Open();
        cmd.Parameters.AddWithValue("@Id",documentId);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            int templateId=Convert.ToInt32(rd[0]);

            return templateId;
        }
        else
        {
            return 0;
        }
    }
}