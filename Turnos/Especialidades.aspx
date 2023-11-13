<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="Turnos.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="Profesionales">Nuestros Profesionales y sus especialidades</h1>
    
       <div class="filter-container" style="display: flex; flex-direction: column; align-items: center; text-align: center;">
    <label for="Filtro" class="control-label" style="margin-bottom: 10px;">Filtrar</label>
    
    <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="Filtro_TextChanged" CssClass="form-control" style="width: 450px; margin-bottom: 10px;" />

    <asp:CheckBox Text="Filtro Avanzado" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
</div>
    
    <% if (filtroAvanzado)
        { %>
    <div class="row justify-content-center">
        <div class ="col-3">
    <div class="mb-3"> 
        <asp:Label Text="campo" runat="server" />
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="Especialidad" />
            <asp:ListItem Text="Sede" />
        </asp:DropDownList>
            </div>
</div>
        <div class ="col-3">
            <div class="mb-3">   
                <asp:Label Text="criterio" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"> 
                </asp:DropDownList>
            </div>
        </div>
        <div class ="col-3">
    <div class="mb-3"> 
        <asp:Label Text="Filtro" runat="server" />
        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
    </div>
          </div>  
            <div class ="col-3">
<div class="mb-3"> 
    <asp:Label Text="Estado" runat="server" />
    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
        <asp:ListItem Text="Todos" />
        <asp:ListItem Text="Activo" />
        <asp:ListItem Text="Inactivo" />
    </asp:DropDownList>
    </div>
      </div> 
       
        </div>

  <div class="row justify-content-center">
    <div class="col-3 text-center"> <!-- Añadido 'text-center' para centrar el contenido del botón -->
        <div class="mb-3">   
            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click"/>
        </div>
    </div>
      <% } %>
</div>
    


        
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dataGridViewMedicos" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" DataKeyNames="Legajo"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="dataGridViewMedicos_PageIndexChanging" OnSelectedIndexChanged="dataGridViewMedicos_SelectedIndexChanged" OnRowDeleting="dataGridViewMedicos_RowDeleting">
                <RowStyle CssClass="gridview-row" />
                <HeaderStyle CssClass="gridview-header" />
                <Columns>
                    <asp:BoundField DataField="Legajo" HeaderText="Legajo" Visible="false" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Sede.NombreSede" HeaderText="Sede" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("Legajo") %>' OnClientClick="return confirm('¿Seguro que desea eliminar este registro?');" CssClass="eliminar-button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" ControlStyle-CssClass="modificar-button" />
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="login-container">
        <a href="AgregarMedico.aspx" class="btn btn-primary">Agregar Médico</a>
    </div>

</asp:Content>


