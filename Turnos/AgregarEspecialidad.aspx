<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="AgregarEspecialidad.aspx.cs" Inherits="Turnos.AgregarEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function validarFormulario() {
            var nombreEspecialidad = document.getElementById('<%=txtNombre.ClientID %>').value;

            if (nombreEspecialidad.trim() === "") {
                alert("Por favor, ingrese el nombre de la especialidad.");
                return false;
            }

            return true;
        }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server" />
<section class="card-login">

    <div class="login-container">

        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre de Especialidad</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" name="txtNombre" />
            <div id="NombreHelp" class="form-text">Ingrese el nombre de la Especialidad.</div>
        </div>  
        <div class="mb-3">
            <asp:Button runat="server" ID="btnAgregar" Text="Aceptar"  CssClass="btn btn-primary" OnClientClick="return validarFormulario();" OnClick="btnAgregar_Click" />
            <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" Onclick="btnCancelar_Click" />
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
