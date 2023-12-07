<%@ Page Title="" Language="C#" MasterPageFile="/WebMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Turnos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="cards-container">
    <!-- Card 1 -->
    <a href="Especialidades.aspx" class="custom-card">
        <i class="fas fa-user-md fa-3x"></i>
        <h2>Profesionales</h2>
    </a>

    <!-- Card 2 -->
    <a href="Patologias.aspx" class="custom-card">
        <i class="fas fa-medkit fa-3x"></i>
        <h2>Especialidades</h2>
    </a>

    <!-- Card 3 -->
    <a href="Sedes.aspx" class="custom-card">
        <i class="fas fa-building fa-3x"></i>
        <h2>Sedes</h2>
    </a>

    <!-- Card 4 -->
    <a href="Usuarios.aspx" class="custom-card">
        <i class="fas fa-users fa-3x"></i>
        <h2>Usuarios</h2>
    </a>

    <!-- Card 5 -->
    <a href="Coberturas.aspx" class="custom-card">
        <i class="fas fa-shield-alt fa-3x"></i>
        <h2>Coberturas</h2>
    </a>

    <!-- Card 6 -->
    <a href="Login.aspx" class="custom-card">
        <i class="fas fa-stethoscope fa-3x"></i>
        <h2>Login</h2>
    </a>
</div>




</asp:Content>




