<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintDocument.aspx.cs" Inherits="PrintDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" integrity="sha384-fLW2N01lMqjakBkx3l/M9EahuwpSfeNvV63J5ezn3uZzapT0u7EYsXMjQV+0En5r" crossorigin="anonymous">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
   

    <style type="text/css">
        @media print {
            .PrintOnly {
                font-size: 10pt;
                line-height: 120%;
                background: white;
            }
        }

        @media screen {
            .PrintOnly {
                display: none;
            }
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <div  class="PrintOnly">
            <div class="container">
                <div style="float: left; width: 85%;">
                    <div style="float: left; margin-left: 5%; margin-top: 5%; width: 15%;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Image/Soft_Incubator.jpeg" Width="100%" />
                    </div>
                    <div style="float: left; margin-left: 8%;width:65%; margin-top: 1%; text-align: center;">
                        <h2><u>
                            <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label></u></h2>
                        <h3><u>
                            <asp:Label ID="lblSubject" runat="server" Text=""></asp:Label></u></h3>
                    </div>
                </div>
                <br />
                <div style="float: left; margin-left: 5%; margin-top: 5%; width: 85%">

                    <asp:Label ID="lblBody" runat="server" Text=""></asp:Label>
                </div>
                <div style="float: left; margin-left: 5%; margin-top: 5%; width: 85%;">
                    <div style="float: left; text-align: left; width: 50%">
                        <h4>
                            <asp:Label ID="lblFooterLeft" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div style="float: left; text-align: right; width: 50%">
                        <h4>
                            <asp:Label ID="lblFooterRight" runat="server" Text=""></asp:Label></h4>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">

            window.print();

   
</script>
          <script >
              window.location = "DMSHomePage.aspx";
          </script>
    </form>
</body>
</html>
