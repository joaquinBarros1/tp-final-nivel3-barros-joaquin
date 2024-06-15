<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f8f9fa;
        }

        .validar {
            color: red;
            font-size: 16px;
        }

        .login-form {
            background: #fff;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

            .login-form .form-group {
                margin-bottom: 20px;
            }

            .login-form .btn {
                width: 100%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="login-form">
                    <h2 class="text-center">Iniciar Sesión</h2>
                    <div class="form-group">
                        <label for="email">Correo Electrónico</label>
                        <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="txtEmail" placeholder="Ingrese su Email" />
                        <asp:RequiredFieldValidator ErrorMessage="* Debes ingresar un Email" ValidationGroup="login" CssClass="validar" ControlToValidate="txtEmail" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="password">Contraseña</label>
                        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtContraseña" placeholder="Ingrese su contraseña" />
                        <asp:Label Text="" ID="lblLogin" CssClass="validar" runat="server" />
                        <asp:RequiredFieldValidator ErrorMessage="* Debes ingresar la contraseña" CssClass="validar" ValidationGroup="login" ControlToValidate="txtContraseña" runat="server" />
                    </div>
                    <asp:Button Text="Ingresar" ValidationGroup="login" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" />
                    <p class="text-center mt-3">¿No tienes una cuenta? <a href="Registro.aspx">Regístrate</a></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
