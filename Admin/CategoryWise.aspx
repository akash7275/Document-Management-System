<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryWise.aspx.cs" Inherits="Admin_CategoryWise" EnableEventValidation="false" %>

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
        <div>
            <div> 
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
                        <li><asp:Button ID="btnLogout" style="background-color:transparent; border:none" runat="server" onclick="btnLogout_Click" Text="Logout" /></li>
                    </ul>
                    <ul class="side-nav" id="mobile-demo">
                        <li><a href="../MakeTemplate.aspx">New Template</a></li>
                        <li><a href="../SelectCategory.aspx">Use Template</a></li>
                        <li><a href="../UploadSignedDocument.aspx">UploadSignedDocument</a></li>
                        <li><a href="DocumentRecords.aspx">Admin Panel</a></li>
                        <li><a href="CategoryWise.aspx">All Documents</a></li>
                       <li><asp:Button ID="btnNavLogout" style="background-color:transparent; border:none; color:black;" runat="server" onclick="btnNavLogout_Click" Text="Logout" /></li>
                    </ul>
                </div>
            </nav>
                 <h2 style="text-align:center;">All Documents</h2>
               <div  style="float:left; width:180px;height:500px;  overflow-y:scroll;overflow-x:hidden;">
                  <div style="text-align:center; color:white; background-color:#EE6E73"> <b>Select Category</b></div>
                <asp:Repeater ID="rptSelectCategory" runat="server">
                    <ItemTemplate>
                        <div style="; color: white; display: inline-block; list-style: none; border-radius: 4%;">
                            <ul>
                                <li style="list-style: none;">
                                <div style="float:left; width:200px">
                                    <asp:Button ID="btnCategory" style="align-content:center;width:150px;" class="btn" runat="server" Text='<%#Eval("Name")%>' CommandName='<%#Eval("Id")%>' CommandArgument='<%#Eval("Id")%>' OnClick="btnCategory_Click"></asp:Button>
                                   </div>
                                </li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                   </div>
            </div>
            <br />
            <br />
            <br />
        </div>
        <div class="container" style="float:left;margin-left:80px;margin-top:-61px;">
            
            <asp:GridView ID="gridViewDocuments" GridLines="Both" runat="server"  AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="100px" >
                        <HeaderTemplate >Document Id</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px">
                        <HeaderTemplate>Subject</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'>
                            </asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="300px"  >
                        <HeaderTemplate >Body</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBody"  runat="server" Text='<%#Eval("Body") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px">
                        <HeaderTemplate>Signed Copy</HeaderTemplate>
                        <ItemTemplate>
                            
                            <asp:Label ID="lblSignedCopy" runat="server" Text='<%#Eval("SignedDocument") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px">
                        <HeaderTemplate>Date Created</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                        <HeaderTemplate>Action</HeaderTemplate>
                        <ItemTemplate>
                          
                             <asp:Button ID="btnDelete" runat="server" CssClass="btn " OnClick="btnDelete_Click" Text="Delete"  CommandArgument='<%#Eval("Id") %>'></asp:Button> 
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                        <HeaderTemplate>Action</HeaderTemplate>
                        <ItemTemplate>
                            
                             <asp:Button ID="btnPrint" runat="server" CssClass="btn " OnClick="btnPrint_Click" Text="Print"  CommandArgument='<%#Eval("Id") %>'></asp:Button>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField >
                        <HeaderTemplate>Action</HeaderTemplate>
                        <ItemTemplate>
                           
                             <asp:Button ID="btnUpload" runat="server" CssClass="btn" OnClick="btnUpload_Click" Text="Upload"  CommandArgument='<%#Eval("Id") %>'></asp:Button>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle  BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle  BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
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
