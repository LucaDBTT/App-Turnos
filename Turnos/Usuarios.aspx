<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Turnos.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Nuestros Usuarios</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="dataGridViewUsuarios" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" DataKeyNames="Dni"
            AllowPaging="true" PageSize="10" OnPageIndexChanging="dataGridViewUsuarios_PageIndexChanging"  OnRowDeleting="dataGridViewUsuarios_RowDeleting">
            <RowStyle CssClass="gridview-row" />
            <HeaderStyle CssClass="gridview-header" />
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" Visible="false" />
                <asp:BoundField DataField="dni" HeaderText="DNI" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="TipoUsuarioNombre" HeaderText="tipo de usuario"/>
                <asp:BoundField DataField="Mail" HeaderText="Correo Electrónico" />
                
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("dni") %>' OnClientClick="return confirm('¿Seguro que desea eliminar este registro?');" CssClass="eliminar-button" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>




</asp:Content>
