<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewTransactionsReportPage.aspx.cs" Inherits="CentuDY.Views.ViewTransactionsReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Report</h1>
    <cr:crystalreportviewer ID="crvReport" runat="server" autodatabind="true"></cr:crystalreportviewer>

</asp:Content>
