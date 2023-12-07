<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Coberturas.aspx.cs" Inherits="Turnos.Coberturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 class="Profesionales">Nuestras Coberturas</h1>
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="dataCoberturas" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" DataKeyNames="idCobertura"
            AllowPaging="true" PageSize="10" OnPageIndexChanging="dataCoberturas_PageIndexChanging" OnSelectedIndexChanged="dataCoberturas_SelectedIndexChanged" OnRowDeleting="dataCoberturas_RowDeleting">
            <RowStyle CssClass="gridview-row" />
            <HeaderStyle CssClass="gridview-header" />
            <Columns>
                <asp:BoundField DataField="idCobertura" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Cobertura" />
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("idCobertura") %>' OnClientClick="return confirm('¿Seguro que desea eliminar este registro?');" CssClass="eliminar-button" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" ControlStyle-CssClass="modificar-button" />
            </Columns>
        </asp:GridView>

    </ContentTemplate>
</asp:UpdatePanel>
<div class="login-container">
    <a href="AgregarCobertura.aspx" class="btn btn-primary">Agregar Cobertura</a>
</div>
        
</asp:Content>
