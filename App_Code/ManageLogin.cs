using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DALHelper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SNP.Enums;

/// <summary>
/// Summary description for ManageLogin
/// </summary>
public class ManageLogin
{
   

    public List<AdminLogin> GetAllUsers(AdminLogin objAdminLogin)
    {
      
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        DataSet ds;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            
            List<SqlParameter> lstLoginDetail = new List<SqlParameter>();
            lstLoginDetail.Add(new SqlParameter("@UserName", objAdminLogin.UserName));

            ds = objDDBDataHelper.GetDataSet("Select * from UserLogin WHERE UserName=@UserName", SQLTextType.Query, lstLoginDetail);
            List<AdminLogin> lstLoginDetails = new List<AdminLogin>();
            int i = 0;
            foreach (DataRow rows in ds.Tables[0].Rows)
            {

                objAdminLogin.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objAdminLogin.UserName = ds.Tables[0].Rows[i][1].ToString();
                objAdminLogin.Password = ds.Tables[0].Rows[i][2].ToString();

                lstLoginDetails.Add(objAdminLogin);
                i++;
            }
            return lstLoginDetails;
        }
    }
}