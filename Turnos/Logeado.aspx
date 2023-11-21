<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Logeado.aspx.cs" Inherits="Turnos.Logeado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Te logeaste correctamente</h1>
    <div class="login-container">
    <asp:Button runat="server" ID="User" Text="Navegar User" CssClass="btn btn-primary" OnClick="User_Click" />
    <asp:Button runat="server" ID="Admin" Text="Navegar Admin" CssClass="btn btn-primary" OnClick="Admin_Click" />
    </div>
</asp:Content>
