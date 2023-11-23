<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Turnos.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     

   <asp:ScriptManager ID="ScriptManager2" runat="server" />
             <h1 class="Profesionales">Crea tu Perfil</h1>
  <section class="card-login">
      <div class="login-container">
          <div class="mb-3">
              <label for="txtDni" class="form-label">DNI del Usuario</label>
              <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" name="txtDni" />
              <div id="DniHelp" class="form-text">Ingrese el DNI del usuario.</div>
          </div>
          <div class="mb-3">
              <label for="txtNombre" class="form-label">Nombre del Usuario</label>
              <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" name="txtNombre" />
              <div id="NombreHelp" class="form-text">Ingrese el nombre del usuario.</div>
          </div>
          <div class="mb-3">
              <label for="txtApellido" class="form-label">Apellido del Usuario</label>
              <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" name="txtApellido" />
              <div id="ApellidoHelp" class="form-text">Ingrese el Apellido del usuario.</div>
          </div>
          <div class="mb-3">
              <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
              <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" />
              <div id="FechaNacimientoHelp" class="form-text">Ingrese la fecha de nacimiento del usuario.</div>
          </div>
          <div class="mb-3">
              <label for="txtNumeroAfiliado" class="form-label">Número de Afiliado</label>
              <asp:TextBox runat="server" ID="txtNumeroAfiliado" CssClass="form-control" name="txtNumeroAfiliado" />
              <div id="NumeroAfiliadoHelp" class="form-text">Ingrese el número de afiliado del usuario.</div>
          </div>
          <div class="mb-3">
              <asp:DropDownList runat="server" ID="ddlCoberturas" CssClass="form-control" name="ddlCoberturas"></asp:DropDownList>
              <div id="CoberturaHelp" class="form-text">Seleccione la cobertura del usuario.</div>
          </div>
          <div class="mb-3">
              <label for="txtCorreo" class="form-label">Correo Electrónico</label>
              <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control" name="txtCorreo" />
              <div id="CorreoHelp" class="form-text">Ingrese el correo electrónico del usuario.</div>
          </div>
          <div class="mb-3">
              <label for="txtTelefono" class="form-label">Teléfono</label>
              <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" name="txtTelefono" />
              <div id="TelefonoHelp" class="form-text">Ingrese el teléfono del usuario.</div>
          </div>
          <div class="mb-3">
              <label for="txtContraseña" class="form-label">Contraseña del Usuario</label>
              <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" TextMode="Password" />
              <div id="ContraseñaHelp" class="form-text">Ingrese la contraseña del usuario.</div>
          </div>

          <div class="mb-3">
              <asp:Button runat="server" ID="btnAgregar" Text="Aceptar" CssClass="btn btn-primary"  OnClick="btnAgregar_Click" />
              <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
          </div>

          <div class="row">
              <div class="col-6">
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                      <contenttemplate>
                      </contenttemplate>
                  </asp:UpdatePanel>
              </div>
          </div>
      </div>
  </section>

</asp:Content>
