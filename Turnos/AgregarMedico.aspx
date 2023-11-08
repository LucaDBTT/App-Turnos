<%@ Page Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Turnos.AgregarMedico" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="card-login">
        <form>
            <div class="login-container">

                <div class="mb-3">
                    <label for="inputNombre" class="form-label">Nombre del Médico</label>
                    <asp:TextBox runat ="server" ID ="txtNombre" CssClass ="form-control" />
                    <div id="NombreHelp" class="form-text">Ingrese el nombre del médico.</div>
                </div>
                <div class="mb-3">
                    <label for="inputApellido" class="form-label">Apellido del Médico</label>
                    <asp:TextBox runat ="server" ID ="txtApellido" CssClass ="form-control" />
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
                    <button type="submit" class="btn btn-primary">Aceptar</button>
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClientClick="return onClickAceptar();" OnClick="btnAceptar_Click" />
                    <button type="button" class="btn btn-outline-danger">Cancelar</button>
                </div>
            </div>
        </form>
    </section>


</asp:Content>
