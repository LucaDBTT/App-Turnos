<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="UserDefault.aspx.cs" Inherits="Turnos.UserDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="content-container">
        <h1 class="user-h1-custom">Necesitás un turno próximo? Reservalo en unos simples pasos</h1>
        <div class="img-container-custom">
            <div class="img-overlay-custom"></div>
            <img src="https://storage.googleapis.com/www-saludiario-com/wp-content/uploads/2022/04/15bf8db3-computadoras-porta%CC%81tiles.jpg" alt="Turno" class="img-fluid img-custom">
        </div>
        <section class="card-login-custom">
            <div class="login-container-custom">
                <h5 class="especialidades-text">Conocé nuestras especialidades y qué profesionales tenemos asignados a ellas. Elegí el que más satisfasga tus necesidades...</h5>
                <asp:Button runat="server" ID="ButtonUser" Text="Conocenos" CssClass="btn btn-primary btn-custom" OnClick="ButtonUse_Click" />
            </div>
        </section>
    </div>
</asp:Content>
