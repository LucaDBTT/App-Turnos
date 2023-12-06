<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="FiltrarMedicos.aspx.cs" Inherits="Turnos.FiltrarMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h1 class="Profesionales">Seleccione Especialidad</h1>

    <div class="container">
        <div class="row">
            <asp:Repeater ID="repRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card mb-3">
                            <img src="<%#Eval("URLimagen") %>" class="card-image card-img-top" alt="..." onerror="this.src='https://camarasal.com/wp-content/uploads/2020/08/default-image-5-1.jpg'">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <div class="login-container">
                                    <a href='<%# "MedicosEspecialidad.aspx?idEspecialidad=" + Eval("id") %>' class="btn btn-primary" runat="server">Ver Medicos</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>