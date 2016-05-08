using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewSignedDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int docid = Convert.ToInt32(Session["docId"]);

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        string retrieveImage = "SELECT SignedDocument from Document where Id=@Id";
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand(retrieveImage, con);
        con.Open();
        cmd.Parameters.AddWithValue("@Id", docid);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            imgSignedDocument.ImageUrl = "~\\SignedDocument\\" + rd[0].ToString();
           
        }

    }
}