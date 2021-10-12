<%@  Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="CentuDY.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:Label ID="usernameLbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="usernameTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passwordTxt" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="rememberMeChk" runat="server" Text="Remember Me" />
        </div>
        <div>
            <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
        </div>
        <asp:Button ID="loginBtn" OnClick="LoginBtn_Click" runat="server" Text="Login" />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Don't Have Account yet? "></asp:Label>
            <asp:HyperLink ID="registerLink" NavigateUrl="~/Views/RegisterPage.aspx" runat="server">Register</asp:HyperLink>
        </div>
    </form>
</body>
</html>
