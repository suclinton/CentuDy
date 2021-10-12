<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="CentuDY.Views.UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:Button ID="updateProfileBtn" OnClick="updateProfileBtn_Click" runat="server" Text="Update Profile" />
    </div>
</asp:Content>
