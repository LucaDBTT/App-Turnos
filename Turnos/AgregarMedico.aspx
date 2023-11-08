<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Turnos.AgregarMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="card-login">
        <form>
            <div class="login-container">

                <div class="mb-3">
                    <label for="inputNombre" class="form-label">Nombre del Médico</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    <div id="NombreHelp" class="form-text">Ingrese el nombre del médico.</div>
                </div>
                <div class="mb-3">
                    <label for="inputApellido" class="form-label">Apellido del Médico</label>

                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
                    <div id="ApellidoHelp" class="form-text">Ingrese el Apellido del médico.</div>
                </div>
                <div class="mb-3">
                    <asp:DropDownList runat="server" ID="ddlEspecialidades" CssClass="form-control"></asp:DropDownList>
                    <div id="EspecialidadHelp" class="form-text">Seleccione la especialidad del médico.</div>
                </div>
                <div class="mb-3">
                    <asp:DropDownList runat="server" ID="ddlSedes" CssClass="form-control"></asp:DropDownList>
                    <div id="SedeHelp" class="form-text">Seleccione la sede del médico.</div>
                </div>
                        
                    <div class="mb-3">
    <button type="button" class="btn btn-primary" onclick="guardarYRedirigir()">Aceptar</button>
    <button type="button" class="btn btn-outline-danger">Cancelar</button>
                    </div>
                   

                
            </div>
        </form>
    </section>

    
    </script>
    <script type="text/javascript">
        function guardarYRedirigir() {
            // Recopilar datos del formulario
            var nombre = document.getElementById('<%= txtNombre.ClientID %>').value;
            var apellido = document.getElementById('<%= txtApellido.ClientID %>').value;
    var especialidad = document.getElementById('<%= ddlEspecialidades.ClientID %>').value;
            var sede = document.getElementById('<%= ddlSedes.ClientID %>').value;

            // Crear un objeto para enviar datos al servidor
            var data = {
                Nombre: nombre,
                Apellido: apellido,
                Especialidad: especialidad,
                Sede: sede
            };

            // Realizar una llamada AJAX al servidor para guardar los datos
            $.ajax({
                type: "POST",
                url: "GuardarDatos.aspx/GuardarMedico", // Cambia esto por la ruta correcta de tu servidor
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // La llamada AJAX se completó con éxito, redirige al usuario
                    window.location.href = "Especialidades.aspx";
                },
                error: function (xhr, status, error) {
                    alert("Error al guardar los datos: " + error);
                }
            });
        }

    </script>


</asp:Content>
