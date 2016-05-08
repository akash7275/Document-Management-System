<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentRecords.aspx.cs" Inherits="DocumentRecords" EnableEventValidation="false" %>

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
    <link href="../Design.css" rel="stylesheet" />
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
                    <li><a href="../MakeTemplate.aspx">New Template</a></li>
                    <li><a href="../SelectCategory.aspx">Use Template</a></li>
                    <li><a href="../UploadSignedDocument.aspx">UploadSignedDocument</a></li>
                    <li><a href="DocumentRecords.aspx">Admin Panel</a></li>
                    <li><a href="CategoryWise.aspx">All Documents</a></li>
                    <li>
                        <asp:Button ID="btnLogout" Style="background-color: transparent; border: none" runat="server" OnClick="btnLogout_Click" Text="Logout" /></li>
                </ul>
                <ul class="side-nav" id="mobile-demo">
                    <li><a href="../MakeTemplate.aspx">New Template</a></li>
                    <li><a href="../SelectCategory.aspx">Use Template</a></li>
                    <li><a href="../UploadSignedDocument.aspx">UploadSignedDocument</a></li>
                    <li><a href="DocumentRecords.aspx">Admin Panel</a></li>
                    <li><a href="CategoryWise.aspx">All Documents</a></li>
                    <li>
                        <asp:Button ID="btnNavLogout" Style="background-color: transparent; border: none; color: black;" runat="server" OnClick="btnNavLogout_Click" Text="Logout" /></li>
                </ul>
            </div>
        </nav>

        <h2 style="text-align: center;">All Documents</h2>
        <div class="container" id="gridview">
            <asp:GridView ID="gridViewDocuments" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" ForeColor="Black" Width="1015px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>Document Id</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Subject</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Body</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBody" runat="server" Text='<%#Eval("Body") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Date Created</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Signed Copy</HeaderTemplate>
                        <ItemTemplate>
                            <%--<asp:Label ID="lblSignedCopy" runat="server" Text='<%#Eval("SignedDocument") %>'></asp:Label>--%>
                            <asp:Button ID="btnview" class="btn" OnClick="btnview_Click" Text="View" runat="server" CommandArgument='<%#Eval("Id") %>'></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>Actions</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" class="btn" OnClick="btnDelete_Click" Text="Delete" runat="server" CommandArgument='<%#Eval("Id") %>'></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Action</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnPrint" class="btn" OnClick="btnPrint_Click" Text="Print" runat="server" CommandArgument='<%#Eval("Id") %>'></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>



        </div>
    </form>
</body>
</html>
