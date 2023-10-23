<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Turnos.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
        body {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin: 0;
        }

        .card {
            border: 1px solid #ccc;
            border-radius: 8px;
            padding: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .login-container {
            text-align: center;
        }

        .login-container input {
            margin-bottom: 10px;
            padding: 8px;
        }

        .login-container h2 {
            margin-bottom: 20px;
        }
    </style>


    <div class="card">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            <form method="post" action="Login.aspx">
                <label for="txtUsername">Nombre de Usuario:</label>
                <input type="text" id="txtUsername" name="txtUsername" required />
                <br />
                <label for="txtPassword">Contraseña:</label>
                <input type="password" id="txtPassword" name="txtPassword" required />
                <br />
                <input type="submit" value="Iniciar Sesión" />
            </form>
        </div>
    </div>


</asp:Content>




