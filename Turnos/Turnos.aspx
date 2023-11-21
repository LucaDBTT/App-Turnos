<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Turnos.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div id="EspecialidadHelp" class="form-text">Seleccione la especialidad</div>
          

                     <div class="row row-cols-1 row-cols-md-3 g-4">
    <asp:Repeater ID="repRepeater"  runat="server">
        <ItemTemplate>
            <div class="card-container card mb-3">
                <img src="<%#Eval("URLimagen") %>" class="card-image card-img-top" alt="..." onerror="this.src='https://camarasal.com/wp-content/uploads/2020/08/default-image-5-1.jpg'">
                <div class="card-body">
                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                    <a href='<%# ".aspx?idEspecialidad=" + Eval("id") %>' class="btn btn-primary" runat="server">Ver Medicos</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

</asp:Content>
