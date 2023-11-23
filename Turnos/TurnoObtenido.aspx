<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="TurnoObtenido.aspx.cs" Inherits="Turnos.TurnoObtenido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="container">
    <h1 class="Profesionales text-center">Detalles del Turno</h1>
    <div class="row justify-content-center align-items-center">
        <div class="col-md-8 offset-md-5"> <!-- Se ha cambiado de col-md-6 a col-md-8 -->
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Detalles del Turno</h5>
                    <div class="form-group">
                        <asp:Label ID="lblMedico" runat="server" CssClass="font-weight-bold mr-2" Text='<%# "ID del Médico: " + Eval("IdMedicoPorEspecialidad") %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblDniPaciente" runat="server" CssClass="font-weight-bold mr-2" Text='<%# "DNI del Paciente: " + Eval("DniPaciente") %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblFecha" runat="server" CssClass="font-weight-bold mr-2" Text='<%# "Fecha: " + Eval("Fecha", "{0:yyyy-MM-dd}") %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblHoraInicio" runat="server" CssClass="font-weight-bold mr-2" Text='<%# "Hora Inicio: " + Eval("HoraInicio", "{0:hh\\:mm}") %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblHoraFin" runat="server" CssClass="font-weight-bold" Text='<%# "Hora Fin: " + Eval("HoraFin", "{0:hh\\:mm}") %>'></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>
