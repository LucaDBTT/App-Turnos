<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Turnos.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="carouselExampleIndicators" class="carousel slide">
    <div class="carousel-indicators">
        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
    </div>
    <div class="carousel-inner">
        <div class="carousel-item active">
            <img src="https://i.pinimg.com/564x/32/a8/a6/32a8a6e1e6e17924a0a74654ef033bbe.jpg" class="d-block w-100" alt="Slide 1" style="height: 400px; object-fit: cover;">
        </div>
        <div class="carousel-item">
            <img src="https://www.rgpeo.com/wp-content/uploads/2020/05/AdobeStock_215071271-1024x341.jpeg" class="d-block w-100" alt="Slide 2" style="height: 400px; object-fit: cover;">
        </div>
        <div class="carousel-item">
            <img src="https://servieratulado.com/Content/images/servier_a_tu_lado_home02.jpg" class="d-block w-100" alt="Slide 3" style="height: 400px; object-fit: cover;">
        </div>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
    </button>
</div>

</asp:Content>




