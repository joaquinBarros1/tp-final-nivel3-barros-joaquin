<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ProyectoWeb._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pxImg {
            width: 340px;
            height: 340px;
            object-fit: cover;
        }

        .Texto {
            font-size: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Sección de Productos -->
    <div class="container mt-5">
        <h1 class="text-center">Bienvenido a ElectroSmart</h1>
        <div class="row">
            <!-- Tarjeta de Producto 1 -->
            <div class="col-md-4 mb-4">
                <div class="card">
                    <img src="https://habitar.com.ar/media/catalog/product/cache/a3071fdb4f29fdd58879fba053f62414/1/0/10_4.jpg" class="card-img-top pxImg" alt="Smartphones">
                    <div class="card-body">
                        <h5 class="card-title">Smartphones</h5>
                        <p class="card-text">Gran variedad de teléfonos celulares, para que encuentres el tuyo</p>
                    </div>
                </div>
            </div>
            <!-- Tarjeta de Producto 2 -->
            <div class="col-md-4 mb-4">
                <div class="card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT48w89z6XYnqSgYppJ9YQUqRmtsuwzVmrDlA&s" class="card-img-top pxImg" alt="Smart TV">
                    <div class="card-body">
                        <h5 class="card-title">Smart TV</h5>
                        <p class="card-text">Dispositivos de TV Smart para disfrutar de tus series y peliculas favoritas</p>
                    </div>
                </div>
            </div>
            <!-- Tarjeta de Producto 3 -->
            <div class="col-md-4 mb-4">
                <div class="card">
                    <img src="https://gorilagames.com/img/Public/1019-producto-ps4-fat-9239.jpg" class="card-img-top pxImg" alt="Consolas de videojuegos">
                    <div class="card-body">
                        <h5 class="card-title">Consolas de videojuegos</h5>
                        <p class="card-text">Contamos con un catálogo de consolas de última generación para los jugadores más exigentes</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <h3>Acerca de nosotros!</h3>
    <p class="Texto">
        Bienvenido a ElectroSmart, tu destino principal para los mejores productos electrónicos. Explora nuestro catálogo de última tecnología, desde smartphones y laptops hasta televisores y gadgets inteligentes. Encuentra productos de las marcas más reconocidas y aprovecha nuestras ofertas exclusivas. Compra ahora y lleva la innovación a tu hogar con ElectroSmart.
    </p>

    <asp:Button Text="Ir al catálogo" ID="btnCatalogo" CssClass="btn btn-primary" OnClick="btnCatalogo_Click" runat="server" />
</asp:Content>
