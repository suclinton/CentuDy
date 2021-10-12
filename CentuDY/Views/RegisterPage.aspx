<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="CentuDY.Views.RegisterPage" %>

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
            <asp:Label ID="confirmpasswordLbl" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="confirmpasswordTxt" TextMode="Password" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="genderLbl" runat="server" Text="Gender "></asp:Label>
            <asp:DropDownList ID="genderDDL" runat="server">
                <asp:ListItem Value="Default">Select Gender</asp:ListItem>
                <asp:ListItem Value="M">Male</asp:ListItem>
                <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:DropDownList>
        </div>

         <div>
            <asp:Label ID="phoneNumberLbl" runat="server" Text="Phone Number"></asp:Label>
            <asp:TextBox ID="phoneNumberTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="addressLbl" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="addressTxt" TextMode="MultiLine" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="registerBtn" OnClick="registerBtn_Click" runat="server" Text="Register" />
        </div>
    </form>
</body>
</html>
