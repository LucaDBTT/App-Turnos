<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="Turnos.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Nuestros Profesionales y sus especialidades</h1>

    <asp:GridView ID="dataGridViewMedicos" runat="server" AutoGenerateColumns="False" CssClass="gridview-style">
    <RowStyle CssClass="gridview-row" />
    <HeaderStyle CssClass="gridview-header" />
    <Columns>
        <asp:BoundField DataField="Legajo" HeaderText="Legajo" Visible="false"/>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />
        <asp:BoundField DataField="Sede.NombreSede" HeaderText="Sede" />
    </Columns>
</asp:GridView>

</asp:Content>
