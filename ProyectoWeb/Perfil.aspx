<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ProyectoWeb.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }

        .body {
            background-color: #f8f9fa;
        }

        .profile-form {
            background: #fff;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

            .profile-form .form-group {
                margin-bottom: 20px;
            }

            .profile-form .btn {
                width: 100%;
            }

        .profile-img {
            max-width: 150px;
            height: auto;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="profile-form">
                    <h2 class="text-center mb-4">Mi Perfil</h2>
                    <div class="form-group">
                        <label for="name">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="* El nombre es requerido" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="* No puede contener más de 30 caracteres" CssClass="validacion" ValidationGroup="perfil" ValidationExpression="^.{0,30}$" ControlToValidate="txtNombre" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="lastname">Apellido</label>
                        <asp:TextBox runat="server" ID="txtApellido" ClientIDMode="Static" CssClass="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="* El apellido es requerido" CssClass="validacion" ControlToValidate="txtApellido" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="* No puede contener más de 30 caracteres" ValidationGroup="perfil" ValidationExpression="^.{0,30}$" CssClass="validacion" ControlToValidate="txtApellido" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="email">Correo Electrónico</label>
                        <asp:TextBox runat="server" ID="txtEmail" ReadOnly="true" Enabled="false" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="profile-img">Imagen de Perfil</label>
                        <input type="file" runat="server" ID="txtImagen" class="form-control" />
                    </div>
                    <div class="text-center">
                        <asp:Image runat="server" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" ImageUrl="https://static.vecteezy.com/system/resources/thumbnails/009/734/569/small/default-avatar-profile-icon-social-media-user-photo-vector.jpg" />
                    </div>
                    <asp:Button runat="server" ID="btnGuardar" ValidationGroup="perfil" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
