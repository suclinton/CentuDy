<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewUsersPage.aspx.cs" Inherits="CentuDY.Views.ViewUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>View Users</h1>

    <div>
        <asp:GridView DataKeyNames="UserId" ID="viewUserGV" AutoGenerateColumns="False" runat="server" OnRowDeleting="viewUserGV_RowDeleting" Visible="true">
            <Columns>
                <asp:BoundField DataField="UserId" Visible="false" HeaderText="ID" SortExpression="UserId" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="RoleName" HeaderText="Role Name" SortExpression="RoleName" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:buttonfield buttontype="button" commandname="delete" text="delete user" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
