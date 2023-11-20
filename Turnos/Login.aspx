<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Turnos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="card-login">
    <div class="container">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <div class="login-container">
                    <h2>Iniciar Sesión</h2>
                    <form method="post" action="Login.aspx">
                        <div class="form-group">
                            <label for="txtUsername">Nombre de Usuario:<br />
                            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                            </label>
                            &nbsp;
                        </div>
                        <div class="form-group">
                            <label for="txtPassword">Contraseña:</label>
                            <br />
       &nbsp;<asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                        </div>
                        
                          



                    </form>
                </div>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </div>
        </div>
    </div>
</section>

</asp:Content>
