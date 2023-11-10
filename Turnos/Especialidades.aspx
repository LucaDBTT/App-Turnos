<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="Turnos.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Nuestros Profesionales y sus especialidades</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dataGridViewMedicos" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" DataKeyNames="Legajo"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="dataGridViewMedicos_PageIndexChanging" OnSelectedIndexChanged="dataGridViewMedicos_SelectedIndexChanged" OnRowDeleting="dataGridViewMedicos_RowDeleting">
                <RowStyle CssClass="gridview-row" />
                <HeaderStyle CssClass="gridview-header" />
                <Columns>
                    <asp:BoundField DataField="Legajo" HeaderText="Legajo" Visible="false" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Sede.NombreSede" HeaderText="Sede" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("Legajo") %>' OnClientClick="return confirm('¿Seguro que desea eliminar este registro?');" CssClass="eliminar-button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" ControlStyle-CssClass="modificar-button" />
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="login-container">
        <a href="AgregarMedico.aspx" class="btn btn-primary">Agregar Médico</a>
    </div>

</asp:Content>


