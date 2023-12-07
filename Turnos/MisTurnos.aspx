<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Turnos.MisTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body, form {
            margin: 0;
            font-family: Arial, sans-serif;
            background-image: url('https://www.gruporecoletas.com/noticias/wp-content/uploads/2022/01/UPS-web.png');
            background-size: cover;
            background-repeat: no-repeat;
        }

        .gridview-style {
            max-width: 1500px;
            width: 80%; /* Ajusta el ancho según sea necesario */
            margin: 0 auto;
            border-collapse: collapse;
            border: 1px solid #dddddd;
            margin-top: 20px;
            background-color: transparent;
            color: black;
        }

        .gridview-style th, .gridview-style td {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        .gridview-style th {
            background-color: #4CAF50;
            color: #fff;
        }

        .gridview-style tr {
            background-color: #f9f9f9; /* Establecer el color de fondo para todas las filas */
            color: black;
        }

        .gridview-style tr:hover {
            background-color: #e5e5e5;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="dgvMisTurnos" runat="server" AutoGenerateColumns="True" CssClass="gridview-style" OnRowCommand="dgvMisTurnos_RowCommand">
            <RowStyle CssClass="gridview-row" />
            <HeaderStyle CssClass="gridview-header" />
            <Columns>
                <asp:TemplateField HeaderText="Cancelar :(">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkCancelarTurno" runat="server" CssClass="btn btn-danger" CommandName="CancelarTurno" CommandArgument='<%# Eval("IdSlot") %>'>
                            <i class="fas fa-times"></i> Cancelar Turno
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:Content>
