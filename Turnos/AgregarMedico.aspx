<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Turnos.AgregarMedico" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <section class="card-login">

        <div class="login-container">

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
                <asp:DropDownList runat="server" ID="ddlEspecialidades" CssClass="form-control" name="ddlEspecialidades"></asp:DropDownList>
                <div id="EspecialidadHelp" class="form-text">Seleccione la especialidad del médico.</div>
            </div>
            <div class="mb-3">
                <asp:DropDownList runat="server" ID="ddlSedes" CssClass="form-control" name="ddlSedes"></asp:DropDownList>
                <div id="SedeHelp" class="form-text">Seleccione la sede del médico.</div>
            </div>
            <div class="mb-3">
                <label for="txtContraseña" class="form-label">Contraseña del Médico</label>
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" TextMode="Password" />
                <div id="ContraseñaHelp" class="form-text">Ingrese la contraseña del médico.</div>
            </div>

            <div class="mb-3">
                <asp:Button runat="server" ID="btnAgregar" Text="Agregar"  CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
            </div>

             <div class="row">
                <div class="col-6">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate >


                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnElminar" CssClass="btn btn-danger" runat="server" OnClick="btnElminar_Click" />
                    </div>

                     <%if(ConfirmaEliminacion) 
                         { %>
                    <div class="mb-3">
                    <asp:CheckBox  runat="server" Text="Confirmar eliminacion"  ID="chkConfirmaEliminacion" />
                    <asp:Button runat="server" Text="Eliminar" ID="btnConfirmaEliminar" CssClass="btn btn-outline-danger"   />
                    </div>
                     <% } %>

                        </ContentTemplate>   
                    </asp:UpdatePanel>

        </div>

    </section>



</asp:Content>
