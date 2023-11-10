<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Sedes.aspx.cs" Inherits="Turnos.Sedes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Nuestras Sedes</h1>
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="dataGridViewMedicos" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" DataKeyNames="IdSede"
            AllowPaging="true" PageSize="10" OnPageIndexChanging="dataGridViewMedicos_PageIndexChanging" OnSelectedIndexChanged="dataGridViewMedicos_SelectedIndexChanged" OnRowDeleting="dataGridViewMedicos_RowDeleting">
            <RowStyle CssClass="gridview-row" />
            <HeaderStyle CssClass="gridview-header" />
            <Columns>
                <asp:BoundField DataField="IdSede" HeaderText="Especialidad" />
                <asp:BoundField DataField="NombreSede" HeaderText="Sede" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("IdSede") %>' OnClientClick="return confirm('¿Seguro que desea eliminar este registro?');" CssClass="eliminar-button" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" ControlStyle-CssClass="modificar-button" />
            </Columns>
        </asp:GridView>

    </ContentTemplate>
</asp:UpdatePanel>
<div class="login-container">
    <a href="AgregarSede.aspx" class="btn btn-primary">Agregar Sede</a>
</div>
</asp:Content>
