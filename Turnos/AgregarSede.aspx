<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="AgregarSede.aspx.cs" Inherits="Turnos.AgregarSede" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
    <script type="text/javascript">
           function validarFormulario() {
               var nombreSede = document.getElementById('<%=txtNombre.ClientID %>').value;

               if (nombreSede.trim() === "") {
                   alert("Por favor, ingrese el nombre de la sede.");
                   return false;
               }

               return true;
           }
       </script>t>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
<section class="card-login">

    <div class="login-container">

        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre de Sede</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" name="txtNombre" />
            <div id="NombreHelp" class="form-text">Ingrese el nombre de la sede.</div>
        </div>         
        <div class="mb-3">
            <asp:Button runat="server" ID="btnAgregar" Text="Aceptar"  CssClass="btn btn-primary" OnClientClick="return validarFormulario();" OnClick="btnAgregar_Click" />
           <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />

        </div>

         <div class="row">
            <div class="col-6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate >

                    </ContentTemplate>   
                </asp:UpdatePanel>

    </div>

</section>




</asp:Content>
