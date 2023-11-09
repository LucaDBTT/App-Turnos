<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="Turnos.Modificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <section class="card-login">
        <form>
            <div class="login-container">
                <div class="mb-3">
                    <label for="inputLegajo" class="form-label">Legajo del Médico</label>
                    <input type="text" class="form-control" id="txtLegajo" aria-describedby="legajoHelp">
                    <div id="legajoHelp" class="form-text">Ingrese el legajo del médico.</div>
                </div>
                <div class="mb-3">
                    <label for="inputNombre" class="form-label">Nombre del Médico</label>
                    <input type="text" class="form-control" id="inputNombre" aria-describedby="NombreHelp">
                    <div id="NombreHelp" class="form-text">Ingrese el nombre del médico.</div>
                </div>
                <div class="mb-3">
                    <label for="inputApellido" class="form-label">Apellido del Médico</label>
                    <input type="text" class="form-control" id="inputApellido" aria-describedby="ApellidoHelp">
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
                    <button type="button" class="btn btn-outline-danger">Cancelar</button>
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
        </div>
            </div>
        </form>
    </section>


</asp:Content>
