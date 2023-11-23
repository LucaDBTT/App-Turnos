<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="MedicosTurno.aspx.cs" Inherits="Turnos.MedicosTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1 class="Profesionales">Lista de médicos por Especialidad</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dgvMedicoPorEspecialidad" runat="server" AutoGenerateColumns="False" DataKeyNames="idMedicoPorEspecialidad"
                CssClass="gridview-style" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvMedicoPorEspecialidad_PageIndexChanging" OnRowDataBound="dgvMedicoPorEspecialidad_RowDataBound">
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
                    <asp:TemplateField HeaderText="Seleccionar Slot">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlSlotsTurno" runat="server" CssClass="form-control" AutoPostBack="false" Visible="false"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkTurno" runat="server" Text="Quiero mi turno!" CommandName="Turno" CommandArgument='<%# Eval("idMedicoPorEspecialidad") %>' CssClass="eliminar-button" OnClick="lnkTurno_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
