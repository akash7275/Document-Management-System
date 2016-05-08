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


public class ManageMakeTemplate
{
    public bool CreateTemplate(Category objCategory, Template objTemplate,Document objDocument)
    {
        //try
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            {
                string checkCatQuery = "SELECT * from Category where Name=@Name";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(checkCatQuery, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Name", objCategory.Name);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    objCategory.Id = Convert.ToInt32(rd[0]);
                }


            }
            {
                string insertTempQuery = "INSERT into Template (CategoryId,Header,Subject,Body,LeftFooter,RightFooter)values(@CategoryId,@Header,@Subject,@Body,@LeftFooter,@RightFooter)" + "Select Scope_Identity()";
                SqlConnection conTemp = new SqlConnection(cs);
                SqlCommand cmdTemp = new SqlCommand(insertTempQuery, conTemp);
                conTemp.Open();
                cmdTemp.Parameters.AddWithValue("@CategoryId", objCategory.Id);
                cmdTemp.Parameters.AddWithValue("@Header", objTemplate.Header);
                cmdTemp.Parameters.AddWithValue("@Subject", objTemplate.Subject);
                cmdTemp.Parameters.AddWithValue("@Body", objTemplate.Body);
                cmdTemp.Parameters.AddWithValue("@LeftFooter", objTemplate.leftFooter);
                cmdTemp.Parameters.AddWithValue("@RightFooter", objTemplate.rightFooter);
                

                int tempId = Convert.ToInt32(cmdTemp.ExecuteScalar());

                string insertDocQuery = "INSERT into Document (TemplateId,Subject,Body)values(@TemplateId,@Subject,@Body)" + "Select Scope_Identity()";
                SqlConnection conDocument = new SqlConnection(cs);
                SqlCommand cmdDocument = new SqlCommand(insertDocQuery, conTemp);
                conDocument.Open();
                cmdDocument.Parameters.AddWithValue("@TemplateId", tempId);
                cmdDocument.Parameters.AddWithValue("@Subject", objDocument.Subject);
                cmdDocument.Parameters.AddWithValue("@Body", objDocument.Body);
                cmdDocument.ExecuteNonQuery();


                return true;
            }

        }
        //catch (Exception ex)
        //{
        //    return false;
        //}

    }

    public DataSet GetDataTemplate()
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Category", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }

   
}

