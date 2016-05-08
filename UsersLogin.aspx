<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersLogin.aspx.cs" Inherits="UsersLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css" />


    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>
    <link href="Design.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <script>
        $('#textarea1').val('New Text');
        $('#textarea1').trigger('autoresize');

    </script>

    <!--Import Google Icon Font-->
    <script>
        $(document).ready(
            function () {
                $(".button-collapse").sideNav();
            });
    </script>
</head>
<body>

    <nav>
        <div class="nav-wrapper">
            <a href="#!" class="brand-logo center">Documentation Management System</a>
            <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
            <ul class="right hide-on-med-and-down"></ul>

        </div>
    </nav>
    <div class="container" id="top">
        <div class="row">
            <form class="col s12" runat="server">
                <div class="row">
                    <div class="input-field col s12">

                        <%--<input id="icon_prefix" type="text" class="validate"/>--%>
                        <i class="material-icons prefix">account_circle</i>
                        <asp:TextBox ID="txtUserEmail"  class="validate" runat="server"></asp:TextBox>
                        <label for="icon_prefix">First Name</label>
                    </div>
                    <div class="input-field col s12">

                        <%-- <input id="icon_prefix2" type="text" class="validate"/>--%>
                         <i class="material-icons prefix">lock</i>
                          <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <label for="icon_prefix">Password</label>
                        <asp:Label ID="labInvalidLogin" runat="server" Text=""></asp:Label>

                    </div>
                    <div style="margin-left:4%;">
                   <%--   <a class="btn"><i class="material-icons left">save</i> <asp:Button  ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="158px" /></a>--%>
                    <asp:LinkButton ID="btnLogin"  CssClass="btn" OnClick="btnLogin_Click" runat="server" >Login</asp:LinkButton>
                   </div>
                </div>
            </form>
        </div>
        


</body>
</html>
