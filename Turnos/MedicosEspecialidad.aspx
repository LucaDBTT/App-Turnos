<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="MedicosEspecialidad.aspx.cs" Inherits="Turnos.MedicosEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Lista de médicos por Especialidad</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dgvMedicoPorEspecialidad" runat="server" AutoGenerateColumns="False" DataKeyNames="idMedicoPorEspecialidad" 
                CssClass="gridview-style" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvMedicoPorEspecialidad_PageIndexChanging" OnRowDeleting="dataGridViewMedicos_RowDeleting">
               <RowStyle CssClass="gridview-row" />
                <HeaderStyle CssClass="gridview-header" />
                <Columns>
                    <asp:BoundField DataField="Legajo" HeaderText="Legajo" Visible="false" />
                    <asp:BoundField DataField="idMedicoPorEspecialidad" HeaderText="idMedicoPorEspecialidad" Visible="false" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="NombreEspecialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="NombreSede" HeaderText="Sede" />
                    <asp:BoundField DataField="DiaSemana" HeaderText="Día de semana" />
                    <asp:BoundField DataField="HoraInicio" HeaderText="Hora inicio" />
                    <asp:BoundField DataField="HoraFin" HeaderText="Hora fin" />
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("idMedicoPorEspecialidad") %>' OnClientClick="return confirm('¿Seguro que desea eliminar este registro?');" CssClass="eliminar-button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="login-container">
        <a href="AgregarEspecialidadMedico.aspx" class="btn btn-primary">Agregar</a>
    </div>
</asp:Content>
