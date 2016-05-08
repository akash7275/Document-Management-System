<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DMSHomePage.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css" />


    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>

    <!--Import Google Icon Font-->

    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="Design.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }

        .ilike-blue-container {
            @extend .blue, .lighten-4;
        }
    </style>
    <script>
        $(document).ready(
            function () {
                $(".button-collapse").sideNav();
            });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav>
                <div class="nav-wrapper">
                    <a href="#!" class="brand-logo">DMS</a>
                    <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
                    <ul class="right hide-on-med-and-down">
                        <li><a href="MakeTemplate.aspx">New Template</a></li>
                        <li><a href="SelectCategory.aspx">Use Template</a></li>
                        <li><a href="UploadSignedDocument.aspx">UploadSignedDocument</a></li>
                        <li><a href="Admin/DocumentRecords.aspx">Admin Panel</a></li>
                        <li><a href="Admin/CategoryWise.aspx">All Documents</a></li>
                        <li>
                            <asp:Button ID="btnLogout" Style="background-color: transparent; border: none" runat="server" OnClick="btnLogout_Click" Text="Logout" /></li>

                    </ul>
                    <ul class="side-nav" id="mobile-demo">
                        <li><a href="MakeTemplate.aspx">New Template</a></li>
                        <li><a href="SelectCategory.aspx">Use Template</a></li>
                        <li><a href="UploadSignedDocument.aspx">UploadSignedDocument</a></li>
                        <li><a href="Admin/DocumentRecords.aspx">Admin Panel</a></li>
                        <li><a href="Admin/CategoryWise.aspx">All Documents</a></li>
                        <li>
                            <asp:Button ID="btnNavLogout" Style="background-color: transparent; border: none; color: black;" runat="server" OnClick="btnNavLogout_Click" Text="Logout" /></li>
                    </ul>
                </div>
            </nav>
            <div class=" container-fluid" style="margin-left:50px;">
                <div class="row">
                    <div class="col s3 AdminRegistration">
                        <h5 style="text-align: center; color: white;"><b>Admin Registration</b></h5>
                        <div style="color: black; margin-top: 15%; margin-left: 10%;">
                            <asp:TextBox ID="txtAdminName" placeholder="Admin Name" Width="80%" Height="15%" BorderStyle="Solid" BackColor="white" runat="server"></asp:TextBox>
                        </div>

                        <div style="color: black; margin-top: 2%; margin-left: 10%;">
                            <asp:TextBox ID="txtAdminPassword" Width="80%" placeholder="Password" Height="15%" BorderStyle="Solid" BackColor="white" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div style="margin-bottom: 20%; margin-left: 10%;">

                            <asp:Button ID="btnSubmit" class="btn" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col s9 image">
                        
                    </div>

                </div>


            </div>

        </div>


    </form>
</body>
</html>
