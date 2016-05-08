<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectTemplate.aspx.cs" Inherits="SelectDocument" EnableEventValidation="false" %>

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
                 <li><asp:Button ID="btnLogout" style="background-color:transparent; border:none" runat="server" onclick="btnLogout_Click" Text="Logout" /></li>
            </ul>
            <ul class="side-nav" id="mobile-demo">
                <li><a href="MakeTemplate.aspx">New Template</a></li>
                <li><a href="SelectCategory.aspx">Use Template</a></li>
                <li><a href="UploadSignedDocument.aspx">UploadSignedDocument</a></li>
                <li><a href="Admin/DocumentRecords.aspx">Admin Panel</a></li>
                <li><a href="Admin/CategoryWise.aspx">All Documents</a></li>
                 <li><asp:Button ID="btnNavLogout" style="background-color:transparent; border:none; color:black;" runat="server" onclick="btnNavLogout_Click" Text="Logout" /></li>
            </ul>
        </div>
    </nav>
    <h3 style="text-align:center;" ">Select Template</h3>
   
        <div>
            <asp:Repeater ID="rptSelectDocument" runat="server">
                <ItemTemplate>
                    <div style=" color: white; display: inline-block; width:30%; padding: .6%; margin: 2px; list-style: none; border-radius: 4%;">
                        <ul>
                            <li style="list-style: none;">
                                <asp:Button ID="btnDocName" Width="100%" class=" btn" runat="server" Text='<%#Eval("Subject")%>' CommandName='<%#Eval("Id")%>' CommandArgument='<%#Eval("Id")%>' OnClick="btnDocName_Click"></asp:Button>
                               
                                
                            </li>
                        </ul>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
