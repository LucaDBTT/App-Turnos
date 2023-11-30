<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Turnos.MisTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<ContentTemplate>
    <asp:GridView ID="dgvMisTurnos" runat="server" AutoGenerateColumns="True">
    <RowStyle CssClass="gridview-row" />
    <HeaderStyle CssClass="gridview-header" />
</asp:GridView>
       
</ContentTemplate>

</asp:Content>
