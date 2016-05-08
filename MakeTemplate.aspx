<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakeTemplate.aspx.cs" Inherits="MakeTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Template</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css" />


    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>

    <!--Import Google Icon Font-->

    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="Design.css" rel="stylesheet" />
    <style type="text/css">
        .ilike-blue-container {
            @extend .blue, .lighten-4;
        }

        .body {
            height: 500px;
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
        </div>
        <h3 style="text-align: center;">Make Your Template</h3>

        <div class="container" id="top">

            <div>
                <div>
                    <asp:TextBox class="header" CssClass="input-field" ID="txtHeader" TextMode="MultiLine" placeholder="Header" runat="server" Font-Bold="True" Font-Names="Adobe Caslon Pro Bold" Font-Size="XX-Large"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:TextBox class="subject" CssClass="input-field" ID="txtSubject" placeholder="Subject" TextMode="MultiLine" runat="server" Font-Bold="True" Font-Names="Adobe Caslon Pro Bold" Font-Size="X-Large"></asp:TextBox>
                </div>
                <br />
                <div>
                    <strong>Category :
                   <asp:DropDownList ID="ddlCategory" AppendDataBoundItems="true" CssClass="browser-default" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
                       <asp:ListItem Text="Choose Category" Value="-1" />
                       <asp:ListItem Text="Other" Value="0" />
                   </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DMSDatabaseConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [Category] ORDER BY [Id] DESC"></asp:SqlDataSource>
                   
                    </strong>
                </div>
                <asp:Label ID="lblCategory" runat="server" Text="Enter Category :"></asp:Label>
                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                <asp:Label ID="lblCategoryAlreadyExist" runat="server" Text=""></asp:Label>
                <br />
                <div>
                    <asp:TextBox class="body" Height="130px" ID="txtBody" CssClass="input-field" placeholder="Body" runat="server" TextMode="MultiLine" Font-Names="Adobe Caslon Pro" Font-Size="Medium"></asp:TextBox>
                </div>
                <br />
                <div style="width: 100%">
                    <div style="width: 40%; float: left">
                        <asp:TextBox class="footer" ID="txtFooterLeft" Style="text-align: left" CssClass="input-field" runat="server" TextMode="MultiLine" Font-Bold="True" Font-Size="Larger"></asp:TextBox>
                    </div>
                    <div style="width: 40%; margin-left: 20%; float: left;">
                        <asp:TextBox class="footer" ID="txtFooterRight" CssClass="input-field" Style="text-align: right" runat="server" TextMode="MultiLine" Font-Bold="True" Font-Size="Larger"></asp:TextBox>
                    </div>
                </div>
                 <asp:LinkButton ID="btnCreate" CssClass="btn" OnClick="btnCreate_Click" runat="server"><i class="material-icons left">save</i> Save</asp:LinkButton>
                <%--<a class="waves-effect waves-light btn"><i class="material-icons left">save</i><asp:Button ID="Button1" runat="server" Text="Save" OnClick="btnCreate_Click" /></a>--%>

            </div>
        </div>
    </form>
</body>
</html>
