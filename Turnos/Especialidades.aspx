<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="Turnos.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Nuestros Profesionales y sus especialidades</h1>

    <asp:GridView ID="dataGridViewMedicos" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" DataKeyNames="Legajo"
        AllowPaging="true" PageSize="10" OnPageIndexChanging="dataGridViewMedicos_PageIndexChanging" OnSelectedIndexChanged="dataGridViewMedicos_SelectedIndexChanged">
        <RowStyle CssClass="gridview-row" />
        <HeaderStyle CssClass="gridview-header" />
        <Columns>
            <asp:BoundField DataField="Legajo" HeaderText="Legajo" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />
            <asp:BoundField DataField="Sede.NombreSede" HeaderText="Sede" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
            <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar" />
           
            
        </Columns>
    </asp:GridView>

    <div class="login-container">
    <a href="AgregarMedico.aspx" class="btn btn-primary">Agregar Médico</a>
    </div>

</asp:Content>
