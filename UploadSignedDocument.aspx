<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadSignedDocument.aspx.cs" Inherits="UploadSignedDocument" %>

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
        /*.auto-style1 {
            font-size: xx-large;
        }*/

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
   <form class="col s12" runat="server">
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
    </div>
     <h3 style="text-align:center;">Upload Signed Image</h3>

    <div class="container" id="top">
        <div class="row">
            
                <div class="row">
                    <div class="input-field col s12">
                        
                        Enter Document Id :<asp:TextBox ID="txtDocumentId" runat="server"></asp:TextBox>
                       <br />
                        <div>
                             <strong>Choose Document :
                   <asp:DropDownList ID="ddlChooseDocument" CssClass="browser-default" OnSelectedIndexChanged="ddlChooseDocument_SelectedIndexChanged" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Subject" DataValueField="Id">
                      
                   </asp:DropDownList>
                             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DMSDatabaseConnectionString %>" SelectCommand="SELECT [Id], [Subject] FROM [Document]"></asp:SqlDataSource>
               </strong>
                        </div>
                        <asp:FileUpload ID="fuSignedDocument" class="btn" runat="server" />

                        <asp:Button ID="btnUploadDocument" class="btn" runat="server" OnClick="btnUploadDocument_Click" Text="Upload" />
                        <br />
                        <asp:Label ID="labUploadStatus" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="labReplace" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnReplace" class="btn" runat="server" OnClick="btnReplace_Click" Text="Replace" />

                    </div>
                </div>
           
        </div>
    </div>



    <%-- <div class="container" style="margin-top: 100px;">
        <div id="uploadDocument">
            <form action="#" runat="server">
                <div class="file-field input-field">
                    <div class="btn">
                        <span>File</span>
                        <input type="file" />
                    </div>
                    <div class="file-path-wrapper">
                        <input class="file-path validate" type="text" placeholder="Upload File" />
                    </div>
                </div>
                <br />
                <div class="file-field input-field">
                    <div class="btn">
                        <span>Submit</span>
                        <input type="file" />
                        <asp:Label ID="labReplace" runat="server"></asp:Label>
                        <asp:Label ID="labUploadStatus" runat="server" Text=""></asp:Label>

                    </div>
                </div>
            </form>
        </div>
    </div>--%>
        </form>
</body>
</html>
