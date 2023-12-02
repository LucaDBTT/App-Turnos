<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Turnos.AgregarMedico" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function validarFormulario() {
            var nombreMedico = document.getElementById('<%=txtNombre.ClientID %>').value;
            var apellidoMedico = document.getElementById('<%=txtApellido.ClientID %>').value;
            var contraseñaMedico = document.getElementById('<%=txtContraseña.ClientID %>').value;

            // Función para verificar si el valor contiene solo letras y no números
            function contieneSoloLetras(valor) {
                return /^[a-zA-Z]+$/.test(valor);
            }

            // Verificar si el campo de nombre está vacío
            if (nombreMedico.trim() === "") {
                alert("Por favor, ingrese el nombre del médico.");
                return false;
            }

            // Verificar si el campo de apellido está vacío
            if (apellidoMedico.trim() === "") {
                alert("Por favor, ingrese el apellido del médico.");
                return false;
            }

            // Verificar si el campo de contraseña está vacío
            if (contraseñaMedico.trim() === "") {
                alert("Por favor, ingrese la contraseña del médico.");
                return false;
            }

            // Verificar si el campo de nombre contiene solo letras
            if (!contieneSoloLetras(nombreMedico)) {
                alert("El nombre no debe contener números.");
                return false;
            }

            // Verificar si el campo de apellido contiene solo letras
            if (!contieneSoloLetras(apellidoMedico)) {
                alert("El apellido no debe contener números.");
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
    <label for="txtSede" class="form-label">Sede del Médico</label>
    <asp:TextBox runat="server" ID="txtSede" CssClass="form-control" name="txtSede" />
    <div id="sedeHelp" class="form-text">Ingrese dni del médico.</div>
</div>


            <div class="mb-3">
    <label for="txtDni" class="form-label">Dni del Médico</label>
    <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" name="txtDni" />
    <div id="dniHelp" class="form-text">Ingrese dni del médico.</div>
</div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre del Médico</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" name="txtNombre" />
                <div id="NombreHelp" class="form-text">Ingrese el nombre del médico.</div>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido del Médico</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" name="txtApellido" />
                <div id="ApellidoHelp" class="form-text">Ingrese el Apellido del médico.</div>
            </div>
             <div class="mb-3">
     <label for="txtEspecialidad" class="form-label">Especialidad del Médico</label>
     <asp:TextBox runat="server" ID="txtEspecialidad" CssClass="form-control" name="txtEspecialidad" />
     <div id="EspecialidadHelp" class="form-text">Ingrese la Especialidad del médico.</div>
 </div>
       <div class="mb-3">
    <label for="ddlDiasLaborales" class="form-label">Días Laborales del Médico</label>
    <asp:DropDownList runat="server" ID="ddlDiasLaborales" CssClass="form-control" AppendDataBoundItems="true">
        <asp:ListItem Text="--Seleccione--" Value="" />
    </asp:DropDownList>
    <div id="DiasLaboralesHelp" class="form-text">Seleccione los Días Laborales del médico.</div>
</div>
 <div class="mb-3 row">
    <div class="col">
        <label for="ddlHorarioInicio" class="form-label">Horario de Inicio del Médico</label>
        <asp:DropDownList runat="server" ID="ddlHorarioInicio" CssClass="form-control">
        </asp:DropDownList>
        <div id="HorarioInicioHelp" class="form-text">Seleccione el Horario de Inicio del médico.</div>
    </div>
    
    <div class="col">
        <label for="ddlHorarioFin" class="form-label">Horario de Fin del Médico</label>
        <asp:DropDownList runat="server" ID="ddlHorarioFin" CssClass="form-control">
        </asp:DropDownList>
        <div id="HorarioFinHelp" class="form-text">Seleccione el Horario de Fin del médico.</div>
    </div>
</div>
      <div class="col">
        <asp:Label runat="server" ID="lblMensajeError" CssClass="text-danger"></asp:Label>
    </div>
            
             <div class="mb-3">
     <label for="txtMail" class="form-label">email del Médico</label>
     <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" name="txtMail" />
     <div id="MailHelp" class="form-text">Ingrese el email del médico.</div>
 </div>
            <div class="mb-3">
                <label for="txtContraseña" class="form-label">Contraseña del Médico</label>
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" TextMode="Password" />
                <div id="ContraseñaHelp" class="form-text">Ingrese la contraseña del médico.</div>
            </div>
            <div class="mb-3">
                <asp:Button runat="server" ID="btnAgregar" Text="Aceptar"  CssClass="btn btn-primary" OnClientClick="return validarFormulario();"  OnClick="btnAgregar_Click" />
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
