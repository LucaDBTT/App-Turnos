<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Turnos.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Nuestros Usuarios</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="dataGridViewUsuarios" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" DataKeyNames="Dni"
            AllowPaging="true" PageSize="10" OnPageIndexChanging="dataGridViewUsuarios_PageIndexChanging" OnSelectedIndexChanged="dataGridViewUsuarios_SelectedIndexChanged" OnRowDeleting="dataGridViewUsuarios_RowDeleting">
            <RowStyle CssClass="gridview-row" />
            <HeaderStyle CssClass="gridview-header" />
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" Visible="false" />
                <asp:BoundField DataField="Dni" HeaderText="DNI" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Cobertura.Nombre" HeaderText="Cobertura" />
                <asp:BoundField DataField="NroAfiliado" HeaderText="Nro Afiliado" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Mail" HeaderText="Correo Electrónico" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" visible="false"/>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("dni") %>' OnClientClick="return confirm('¿Seguro que desea eliminar este registro?');" CssClass="eliminar-button" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" ControlStyle-CssClass="modificar-button" />
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
<div class="login-container">
    <a href="AgregarUsuario.aspx" class="btn btn-primary">Agregar Usuario</a>
</div>



</asp:Content>
