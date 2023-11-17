﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="MedicosEspecialidad.aspx.cs" Inherits="Turnos.MedicosEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1> Lista de medicos por Especialidad</h1>
     <asp:GridView ID="dgvMedicoPorEspecialidad" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" >
    <Columns>
        <asp:BoundField DataField="medico.Legajo" HeaderText="Legajo" Visible="false" />
        <asp:BoundField DataField="medico.Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="medico.Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Especialidades.Nombre" HeaderText="Especialidad" />
        <asp:BoundField DataField="Sede.NombreSede" HeaderText="Sede" />
        <asp:BoundField DataField="HorariosLaborales.DiaSemana" HeaderText="Dia de semana" />
        <asp:BoundField DataField="HorariosLaborales.HoraInicio" HeaderText="Hora inicio" />
        <asp:BoundField DataField="HorariosLaborales.HoraFin" HeaderText="Hora fin" />
        <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" ControlStyle-CssClass="modificar-button" />
    </Columns>
</asp:GridView>

</asp:Content>