<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="MedicosEspecialidad.aspx.cs" Inherits="Turnos.MedicosEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de médicos por Especialidad</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dgvMedicoPorEspecialidad" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" DataKeyNames="Legajo" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvMedicoPorEspecialidad_PageIndexChanging" OnSelectedIndexChanged="dgvMedicoPorEspecialidad_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Legajo" HeaderText="Legajo" Visible="false" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="NombreEspecialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="NombreSede" HeaderText="Sede" />
                    <asp:BoundField DataField="DiaSemana" HeaderText="Día de semana" />
                    <asp:BoundField DataField="HoraInicio" HeaderText="Hora inicio" />
                    <asp:BoundField DataField="HoraFin" HeaderText="Hora fin" />
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar Especialidad" ControlStyle-CssClass="modificar-button" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
