<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakeDocument.aspx.cs" Inherits="MakeDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EDIT TEMPLATE</title>
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
           <h3 style="text-align:center;" ">Make Your Document</h3>
        <div class="container">
            
            <div>
                <asp:TextBox class="header" CssClass="input-field" ID="txtHeader" TextMode="MultiLine" placeholder="Header" runat="server" Font-Bold="True" Font-Names="Adobe Caslon Pro Bold" Font-Size="XX-Large"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox class="subject" CssClass="input-field" ID="txtSubject" placeholder="Subject" TextMode="MultiLine" runat="server" Font-Bold="True" Font-Names="Adobe Caslon Pro Bold" Font-Size="X-Large"></asp:TextBox>
            </div>
            <br />
            <br />
            <div>
                <asp:TextBox class="body" Height="130px" ID="txtBody" CssClass="input-field" placeholder="Body" runat="server" TextMode="MultiLine" Font-Names="Adobe Caslon Pro" Font-Size="Medium"></asp:TextBox>
            </div>
            <br />
            <div style="width:100%">
            <div style="width: 40%; float: left">
                <asp:TextBox class="footer" ID="txtFooterLeft" Style="text-align: left" CssClass="input-field" runat="server" TextMode="MultiLine" Font-Bold="True" Font-Size="Larger"></asp:TextBox>
            </div >
            <div style="width: 40%;  margin-left:20%; float: left;">
                <asp:TextBox class="footer" ID="txtFooterRight" CssClass="input-field" Style="text-align: right" runat="server" TextMode="MultiLine" Font-Bold="True" Font-Size="Larger"></asp:TextBox>
            </div>
                </div>
            <br />

            <div>
               <%-- <a class="waves-effect waves-light btn"><i class="material-icons left">save</i>
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" /></a>
               --%>
                   <asp:LinkButton ID="btnSubmit" CssClass="btn" OnClick="btnSubmit_Click" runat="server"><i class="material-icons left">save</i> Save</asp:LinkButton>
               <%-- <i class="material-icons left">print</i>
                    <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn" OnClick="btnPrint_Click" />--%>
                     <asp:LinkButton ID="btnPrint" CssClass="btn" OnClick="btnPrint_Click" runat="server"><i class="material-icons left">print</i> Print</asp:LinkButton>
            </div>
           
        </div>
    </form>
</body>
</html>
