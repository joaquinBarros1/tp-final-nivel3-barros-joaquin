<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="ProyectoWeb.Nosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .header {
            background: #343a40;
            color: #fff;
            padding: 40px 0;
            text-align: center;
        }

            .header h1 {
                font-size: 3rem;
                margin-bottom: 10px;
            }

            .header p {
                font-size: 1.2rem;
            }

        .section {
            padding: 60px 0;
        }

            .section h2 {
                font-size: 2rem;
                margin-bottom: 20px;
            }

        .contact-form .btn {
            width: 100%;
        }

        .founder-img {
            max-width: 100%;
            height: auto;
            border-radius: 10px;
        }

        p {
            font-size: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="header">
        <div class="container">
            <h1>Bienvenido a ElectroSmart</h1>
            <p>Tu destino principal para los mejores productos electrónicos</p>
        </div>
    </header>

    <div class="container section">
        <div class="row">
            <div class="col-md-6">
                <h2>Nuestra Historia</h2>
                <p>ElectroSmart fue fundada por Joaquin Barros, un apasionado de la tecnología con una visión clara: hacer que la tecnología avanzada sea accesible para todos. Joaquin creció en un pequeño pueblo, donde el acceso a la tecnología era limitado. Desde joven, soñó con cambiar esto.</p>
                <p>Después de graduarse en ingeniería electrónica, trabajó en varias empresas tecnológicas donde adquirió una vasta experiencia. En 2010, decidió fundar ElectroSmart con el objetivo de ofrecer productos de alta calidad a precios asequibles y de contribuir al desarrollo de comunidades menos favorecidas.</p>
                <p>Hoy, ElectroSmart es un referente en el sector, conocido no solo por sus productos, sino también por su compromiso social. Gracias a la visión de Joaquin y al apoyo de un equipo dedicado, seguimos creciendo y haciendo una diferencia positiva en el mundo.</p>
            </div>
            <div class="col-md-6">
                <img src="https://www.mendozapost.com/files/image/7/7138/54b6ead940c07.jpg" class="img-fluid" alt="Productos Electrónicos">
            </div>
        </div>
    </div>

    <div class="container section bg-light">
        <div class="row">
            <div class="col-md-6">
                <img src="https://eldebate.com.ar/wp-content/uploads/2020/08/empresa-electronica.jpg" class="founder-img" alt="Joaquin Barros">
            </div>
            <div class="col-md-6">
                <h2>Nuestra Misión</h2>
                <p>En ElectroSmart, nos comprometemos a ofrecerte lo último en tecnología. Nuestra misión es proporcionar productos electrónicos de alta calidad a precios competitivos, garantizando la satisfacción de nuestros clientes a través de un excelente servicio y una experiencia de compra inigualable.</p>
                <p>Creemos en retribuir a la comunidad. Por ello, parte de nuestras ganancias se destinan a fundaciones sin fines de lucro que trabajan en proyectos educativos y tecnológicos. Así, cada compra que realizas no solo mejora tu vida, sino también la de muchas otras personas.</p>
            </div>
        </div>
    </div>
</asp:Content>
