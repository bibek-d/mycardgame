<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
<link href="css/Style.css" rel="stylesheet" type="text/css" />
   <script src="js/jquery-1.8.2.js" type="text/javascript"></script>
<script src="js/Jcrop.js" type="text/javascript"></script>
<link href="css/Jcrop.css" rel="stylesheet" type="text/css" />
    
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('#<%=imgToCrop.ClientID%>').Jcrop({
            onSelect: getAreaToCrop
        });
    });
    function getAreaToCrop(c) {
        $('#XCoordinate').val(parseInt(c.x));
        $('#YCoordinate').val(parseInt(c.y));
        $('#Width').val(parseInt(c.w));
        $('#Height').val(parseInt(c.h));
    }
    </script>
<title>Crop test</title>
</head>
<body class="gamebackground">
    <form id="form1" runat="server">
<asp:Button ID="Button1" runat="server" Text="Back"  PostBackUrl="~/Game.aspx"/>
    <div>
        <fieldset>
            <legend>Upload Your picture to display..</legend>
            <table style="width: 540px">
                <tr>
                    <td>
                        Select image to upload :
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Image ID="imgCropped" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" Visible="false" OnClick="btnReset_Click" />
                    </td>
                  <td>
                        <asp:Button ID="gotoG" runat="server" Text="Goto Game" Visible="false" OnClick="gotoGame"/></td>
                
                </tr>
            </table>
            <asp:Panel ID="pnlCrop" runat="server" Visible="false" Width="700px">
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="imgToCrop" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCrop" runat="server" Text="Crop & Save" OnClick="btnCrop_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input id="XCoordinate" type="hidden" runat="server" />
                            <input id="YCoordinate" type="hidden" runat="server" />
                            <input id="Width" type="hidden" runat="server" />
                            <input id="Height" type="hidden" runat="server" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </fieldset>
    </div>
    
    </form>
</body>

</html>


