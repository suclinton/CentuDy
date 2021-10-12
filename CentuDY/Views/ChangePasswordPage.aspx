<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePasswordPage.aspx.cs" Inherits="CentuDY.Views.ChangePasswordPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="oldPasswordLabel" runat="server" Text="Old password: "></asp:Label>
        <asp:TextBox ID="oldPasswordText" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <asp:Label ID="newPasswordLabel" runat="server" Text="New password: "></asp:Label>
        <asp:TextBox ID="newPasswordText" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <asp:Label ID="newPasswordConfirmLabel" runat="server" Text="Confirm new password: "></asp:Label>
        <asp:TextBox ID="confirmNewPasswordText" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="updatePasswordBtn" OnClick="updatePasswordBtn_Click" runat="server" Text="Update Password" />
    </div>

</asp:Content>
