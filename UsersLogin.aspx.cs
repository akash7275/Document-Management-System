using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UsersLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["Login"]) == 1)
        {
            Response.Redirect("DMSHomePage.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
         AdminLogin objAdminLogin = new AdminLogin();

        ManageLogin objManageLogin = new ManageLogin();



        string userName = txtUserEmail.Text, password = txtPassword.Text;

        objAdminLogin.UserName = txtUserEmail.Text;
        objAdminLogin.Password = txtPassword.Text;

        List<AdminLogin> lstLoginDetails = new List<AdminLogin>();

        lstLoginDetails = objManageLogin.GetAllUsers(objAdminLogin);

        if (lstLoginDetails.Count == 0)
        {
            labInvalidLogin.Text = "User not registered with us.";
        }

        else
        {
            for (int i = 0; i < lstLoginDetails.Count; i++)
            {

                if (userName == lstLoginDetails[i].UserName && password == lstLoginDetails[i].Password)
                {
                    Session["LOGIN"] = 1;
                    Response.Redirect("DMSHomePage.aspx");

                }
                else if (userName == lstLoginDetails[i].UserName && password != lstLoginDetails[i].Password)
                {

                    labInvalidLogin.Text = "Incorrect Password";

                }

            }
        }
        



    }
    }
