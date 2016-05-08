using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.IO;
using SNP.Enums;
public class ManageMakeDocument
{
    public Template RetreiveTemplate(Template objTemplate)
    {
        try
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string retrieveTemp = "SELECT * from Template where Id=@Id";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(retrieveTemp, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", objTemplate.Id);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                objTemplate.CategoryId = Convert.ToInt32(rd[1]);
                objTemplate.Header = rd[2].ToString();
                objTemplate.Subject = rd[3].ToString();
                objTemplate.Body = rd[4].ToString();
                objTemplate.leftFooter = rd[5].ToString();
                objTemplate.rightFooter = rd[6].ToString();
                return objTemplate;
            }
            else
            {
                return objTemplate;
            }
        }

        catch (Exception ex)
        {
            return objTemplate;
        }

    }

    public StatusMakeDocument MakeNewDocument(Document objDocument)
    {
        StatusMakeDocument objStatusMakeDocument = new StatusMakeDocument();
        try
        {


            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string insertDocumentQuery = "INSERT into Document (TemplateId,Subject,Body)values(@TemplateId,@Subject,@Body)" + "Select Scope_Identity()";
            SqlConnection conDocument = new SqlConnection(cs);
            SqlCommand cmdDocuemnt = new SqlCommand(insertDocumentQuery, conDocument);
            conDocument.Open();
            cmdDocuemnt.Parameters.AddWithValue("@TemplateID", objDocument.TemplateID);
            cmdDocuemnt.Parameters.AddWithValue("@Subject", objDocument.Subject);
            cmdDocuemnt.Parameters.AddWithValue("@Body", objDocument.Body);

            //cmdDocuemnt.ExecuteNonQuery();


            objStatusMakeDocument.saved = true;
            objStatusMakeDocument.id = Convert.ToInt32(cmdDocuemnt.ExecuteScalar());

            return objStatusMakeDocument;
        }

        catch (Exception ex)
        {
            objStatusMakeDocument.saved = false;
            objStatusMakeDocument.id = 0;
            return objStatusMakeDocument;
        }
    }

    public StatusMakeDocument MakeNewTemplateDocument(Template objNewTemplate, Document objNewDocument)
    {
        StatusMakeDocument objStatusMakeDocument = new StatusMakeDocument();

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        try
        {
            {
                string insertTempQuery = "INSERT into Template (CategoryId,Header,Subject,Body,LeftFooter,RightFooter)values(@CategoryId,@Header,@Subject,@Body,@LeftFooter,@RightFooter)" + "Select Scope_Identity()";
                SqlConnection conTemp = new SqlConnection(cs);
                SqlCommand cmdTemp = new SqlCommand(insertTempQuery, conTemp);
                conTemp.Open();
                cmdTemp.Parameters.AddWithValue("@CategoryId", objNewTemplate.CategoryId);
                cmdTemp.Parameters.AddWithValue("@Header", objNewTemplate.Header);
                cmdTemp.Parameters.AddWithValue("@Subject", objNewTemplate.Subject);
                cmdTemp.Parameters.AddWithValue("@Body", objNewTemplate.Body);
                cmdTemp.Parameters.AddWithValue("@LeftFooter", objNewTemplate.leftFooter);
                cmdTemp.Parameters.AddWithValue("@RightFooter", objNewTemplate.rightFooter);

                objNewDocument.TemplateID = Convert.ToInt32(cmdTemp.ExecuteScalar());

            }



            {
                string insertDocumentQuery = "INSERT into Document (TemplateId,Subject,Body)values(@TemplateId,@Subject,@Body)" + "Select Scope_Identity()";
                SqlConnection conDocument = new SqlConnection(cs);
                SqlCommand cmdDocuemnt = new SqlCommand(insertDocumentQuery, conDocument);
                conDocument.Open();
                cmdDocuemnt.Parameters.AddWithValue("@TemplateID", objNewDocument.TemplateID);
                cmdDocuemnt.Parameters.AddWithValue("@Subject", objNewDocument.Subject);
                cmdDocuemnt.Parameters.AddWithValue("@Body", objNewDocument.Body);

                objStatusMakeDocument.id = Convert.ToInt32(cmdDocuemnt.ExecuteScalar());
                objStatusMakeDocument.saved = true;
                return objStatusMakeDocument;
            }
        }

        catch (Exception ex)
        {
            objStatusMakeDocument.saved = false;
            objStatusMakeDocument.id = 0;
            return objStatusMakeDocument;
        }

    }
    public DataSet GetDataDocument(int SelectedId)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            // SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Document WHERE TemplateId='"+SelectedId+"'", con);
            SqlDataAdapter da = new SqlDataAdapter("Select objDOcument.Id, objDocument.Subject,objDocument.Body,objDocument.SignedDocument,objDocument.Date From Category objCategory, Template objTemplate, Document objDocument WHERE objCategory.Id='" + SelectedId + "' AND objDocument.TemplateId=objTemplate.Id AND objTemplate.CategoryId=objCategory.Id", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }

    public DataSet GetDataTemplate(int SelectedId)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {

            SqlDataAdapter da = new SqlDataAdapter("Select * FROM TEMPLATE where CategoryId='" + SelectedId + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }


    public UploadStatus CheckSignedDocument(Document objDocument)
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        string retrieveDocument = "SELECT * from Document where Id=@Id";
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand(retrieveDocument, con);
        con.Open();
        cmd.Parameters.AddWithValue("@Id", objDocument.Id);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            if (rd[5] == DBNull.Value)
            {
                return UploadStatus.NotExist;
            }
            else
            { return UploadStatus.AlreadyExist; }
        }
        return UploadStatus.InvalidDocId;
    }
    public bool UploadSignedDocument(Document objDocument)
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        string insertDocumentQuery = "UPDATE Document SET SignedDocument=@SignedDocument WHERE Id=@Id";
        SqlConnection conDocument = new SqlConnection(cs);
        SqlCommand cmdDocuemnt = new SqlCommand(insertDocumentQuery, conDocument);
        conDocument.Open();
        cmdDocuemnt.Parameters.AddWithValue("@Id", objDocument.Id);
        cmdDocuemnt.Parameters.AddWithValue("@SignedDocument", objDocument.SignedDocument);
        cmdDocuemnt.ExecuteNonQuery();
        return true;
    }

    public List<Document> GetAllDocument()
    {
        List<Document> listDocuments = new List<Document>();
        try
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string selectQuery = "SELECT * from Document";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Document objDocument = new Document();
                objDocument.Id = Convert.ToInt32(rd["Id"]);
                objDocument.Subject = rd["Subject"].ToString();
                objDocument.Body = rd["Body"].ToString();
                objDocument.SignedDocument = rd["SignedDocument"].ToString();
                objDocument.Date = rd["Date"].ToString();
                listDocuments.Add(objDocument);
            }
        }
        catch
        {

        }
        return listDocuments;
    }



    public static int DeleteDocument(int Id)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        string getCategoryId = "Select objCategory.Id from Category objCategory,Template objTemplate, Document objDocument where objDocument.id='" + Id + "' AND objDocument.TemplateId=objTemplate.Id anD objTemplate.CategoryId=objCategory.Id";
        string deleteQuery = "DELETE from Document where Id=@Id";
        using (SqlConnection con = new SqlConnection(CS))
        {

            SqlCommand cmdCatId = new SqlCommand(getCategoryId, con);
            con.Open();
            SqlDataReader rd = cmdCatId.ExecuteReader();


            int DocumentId = 0;
            if (rd.Read())
            {
                DocumentId = Convert.ToInt32(rd[0]);

            }
            con.Close();

            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            con.Close();



            return DocumentId;
        }
    }

    public List<Document> GetCategorisedDocument(int SelectedId)
    {
        List<Document> listCategoryDocuments = new List<Document>();
        try
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string selectQuery = "SELECT * FROM Document WHERE TemplateId='" + SelectedId + "'";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand(selectQuery, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Document objCategoryDocument = new Document();
                objCategoryDocument.Id = Convert.ToInt32(rd["Id"]);
                objCategoryDocument.Subject = rd["Subject"].ToString();
                objCategoryDocument.Body = rd["Body"].ToString();
                objCategoryDocument.SignedDocument = rd["SignedDocument"].ToString();
                objCategoryDocument.Date = rd["Date"].ToString();
                listCategoryDocuments.Add(objCategoryDocument);
            }
        }
        catch
        {

        }
        return listCategoryDocuments;
    }


    public object GetDataDocument()
    {
        throw new NotImplementedException();
    }

   
}
