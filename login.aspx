<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">


<head>
<link rel="Stylesheet" type="text/css" href="css/StyleSheet.css" />
<link rel="shortcut icon" href="image/ti.png" type="image/png" />
    <title> Free In-Between, Card Game.</title>
   <script type="text/javascript">
   
       function SwapDivsWithClick(div1, div2) {
           d1 = document.getElementById(div1);
           d2 = document.getElementById(div2);
          
               d1.style.display = "none";
               d2.style.display = "block";
       }
       
</script>


    
</head>
<body id="background">
<form runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id="absolute"><br /><br />
<div class="title"></div>

<table style="color:White">
<p style="color:white"></p>
<tr><th colspan="2">Login Here</th></tr>
<tr><td><asp:Label CssClass="label-text" ID="Label1" runat="server" Text="Username" ></asp:Label></td>
    <td><asp:TextBox CssClass="css-input" ID="uname" runat="server"></asp:TextBox></td></tr>
<tr><td></td>
<td>&nbsp;</td></tr>
<tr><td><asp:Label CssClass="label-text" ID="Label2" runat="server"  Text="Password"></asp:Label></td>
    <td><asp:TextBox CssClass="css-input" ID="pass" textmode="password" runat="server"></asp:TextBox></td></tr>
    <tr><td></td><td><asp:Button ID="Button1" CssClass="btn" runat="server" Text="Login" onclick="logon" /></td></tr>
</table>
    


<p style="color:Red">
<asp:Label ID="lblNotice" runat="server" Text="Label"></asp:Label><br />
Not a Member Yet????
</p>


  <p style="text-align:center; font-weight:bold; font-style:italic;">
  
<a href="javascript:SwapDivsWithClick('absolute','iamRep')">(Sign Up)</a>
</p>
</div>


<div id="iamRep" >
<div class="title"></div>
<p style="color:Red; font-size:x-large">Sign Up
</p> <br />
<asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" runat="server">
<ContentTemplate>
<table style="color:White">
    <caption>
        <p style="color:white">
            <tr>
                <td>
                    <asp:Label ID="Label3" CssClass="label-text" runat="server" Text="USERNAME"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" CssClass="css-input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="r" 
                        ControlToValidate="TextBox1" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" CssClass="label-text" runat="server" Text="PASSWORD"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" CssClass="css-input" runat="server" textmode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="r"
                        ControlToValidate="TextBox2" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" CssClass="label-text" runat="server" Text="RE-PASSWORD"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" CssClass="css-input" runat="server" textmode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="r"
                        ControlToValidate="TextBox3" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" CssClass="label-text" runat="server" Text="EMAIL"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" CssClass="css-input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="r"
                        ControlToValidate="TextBox4" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="javascript:SwapDivsWithClick('iamRep','absolute')">(Login)</a></td>
                <td>
                    <asp:Button ID="Button2" runat="server" CssClass="btn" ValidationGroup="r" onclick="register" 
                        Text="submit" />
                </td>
            </tr>
        </p>
    </caption>
</table>
<asp:Label ID="Labelinfo" runat="server" ForeColor="Red"></asp:Label>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="Button2" />
</Triggers>
</asp:UpdatePanel>
    
 

</div>
</form>
</body>
</html>
