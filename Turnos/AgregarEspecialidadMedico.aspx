<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="AgregarEspecialidadMedico.aspx.cs" Inherits="Turnos.ModificarEspecialidadMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <section class="card-login">

        <div class="login-container">
            <div class="mb-3">
                <label for="txtLegajo" class="form-label">Legajo del Médico</label>
                <asp:DropDownList runat="server" ID="ddlLegajos" CssClass="form-control" name="ddlLegajos"></asp:DropDownList>
                <div id="LegajosHelp" class="form-text">Seleccione lel legajo del médico.</div>
            </div>
            <div class="mb-3">
                <label for="txtEspe" class="form-label">Especialidades del Médico</label>
                <asp:DropDownList runat="server" ID="ddlEspecialidades" CssClass="form-control" name="ddlEspecialidades"></asp:DropDownList>
                <div id="EspecialidadHelp" class="form-text">Seleccione la especialidad del médico.</div>
            </div>
            <div class="mb-3">
                <label for="txtSede" class="form-label">Sede del Médico</label>
                <asp:DropDownList runat="server" ID="ddlSedes" CssClass="form-control" name="ddlSedes"></asp:DropDownList>
                <div id="SedeHelp" class="form-text">Seleccione la sede del médico.</div>
            </div>
            <div class="mb-3">
                <label for="txtHorarios" class="form-label">Horarios del Médico</label>
                <asp:DropDownList runat="server" ID="ddlHorarios" CssClass="form-control" name="ddlHorarios"></asp:DropDownList>
                <div id="HorariosHelp" class="form-text">Seleccione el id horario.</div>
            </div>

            <div class="mb-3">
                <asp:Button runat="server" ID="btnAgregar" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
            </div>

            <div class="row">
                <div class="col-6">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
    </section>



</asp:Content>
