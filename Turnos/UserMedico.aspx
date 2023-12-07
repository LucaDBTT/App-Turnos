<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="UserMedico.aspx.cs" Inherits="Turnos.UserMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <div class="content-container">
     <h1 class="user-h1-custom">Gestionar mis turnos :)</h1>
     <div class="img-container-custom">
         <div class="img-overlay-custom"></div>
         <img src="https://images.ecestaticos.com/FqClzTvHPPGqw7BZal2YZMuQcz8=/22x11:1829x1366/1200x899/filters:fill(white):format(jpg)/f.elconfidencial.com%2Foriginal%2Faf3%2F277%2F71a%2Faf327771a6b40b5f2b2811ae677db4b5.jpg" alt="Turno" class="img-fluid img-custom" style="width:700px; height:auto;">
     </div>
     <section class="card-login-custom">
         <div class="login-container-custom">
             <h5 class="especialidades-text">Visualiza los turnos que tenes agendados doc!</h5>
             <asp:Button runat="server" ID="ButtonUser" Text="Conocenos" CssClass="btn btn-primary btn-custom" OnClick="ButtonUse_Click" />
         </div>
     </section>
 </div>


</asp:Content>
