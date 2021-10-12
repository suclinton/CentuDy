<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProfilePage.aspx.cs" Inherits="CentuDY.Views.ViewProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="usernameLbl" runat="server" Text="Username: "></asp:Label>
        <asp:Label ID="username" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="nameLbl" runat="server" Text="Name: "></asp:Label>
        <asp:Label ID="name" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="genderLbl" runat="server" Text="Gender: "></asp:Label>
        <asp:Label ID="gender" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="phoneNumberLbl" runat="server" Text="Phone Number: "></asp:Label>
        <asp:Label ID="phoneNumber" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="addressLbl" runat="server" Text="Address: "></asp:Label>
        <asp:Label ID="address" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="updateProfileBtn" OnClick="updateProfileBtn_Click" runat="server" Text="Update Profile" />
        <asp:Button ID="changePasswordBtn" OnClick="changePasswordBtn_Click" runat="server" Text="Change Password" />
    </div>

</asp:Content>
