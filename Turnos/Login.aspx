<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Turnos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="card">
    <div class="container">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <div class="login-container">
                    <h2>Iniciar Sesión</h2>
                    <form method="post" action="Login.aspx">
                        <div class="form-group">
                            <label for="txtUsername">Nombre de Usuario:</label>
                            <input type="text" class="form-control" id="txtUsername" name="txtUsername" required />
                        </div>
                        <div class="form-group">
                            <label for="txtPassword">Contraseña:</label>
                            <input type="password" class="form-control" id="txtPassword" name="txtPassword" required />
                        </div>
                        <button type="submit" class="btn btn-primary">Iniciar Sesión</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</section>

</asp:Content>
