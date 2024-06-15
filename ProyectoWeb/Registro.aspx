<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoWeb.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        .registration-form {
            background: #fff;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

            .registration-form .form-group {
                margin-bottom: 20px;
            }

            .registration-form .btn {
                width: 100%;
            }

            .validar {
                color:red;
                font-size:16px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="registration-form">
                    <h2 class="text-center">Crear una cuenta</h2>
                    <div class="form-group">
                        <label for="email">Correo Electrónico</label>
                        <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="txtEmail" placeholder="Ingrese su Email" />
                        <asp:Label Text="" ID="lblEmail" CssClass="validar" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvEmail" CssClass="validar" ValidationGroup="registro" ErrorMessage="* Ingrese un email para registrarse" ControlToValidate="txtEmail" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="* Utiliza formato Email (aaa@aaa.com)" ControlToValidate="txtEmail" ValidationGroup="registro" CssClass="validar" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="password">Contraseña</label>
                        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtContraseña" placeholder="Ingrese su contraseña" />
                        <asp:RequiredFieldValidator ErrorMessage="* Ingresa una contraseña para registrarte" ValidationGroup="registro" CssClass="validar" ControlToValidate="txtContraseña" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="* Máximo 20 caracteres" CssClass="validar" ValidationGroup="registro" ValidationExpression=".{0,20}$" ControlToValidate="txtContraseña" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="confirm-password">Confirmar Contraseña</label>
                        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtConfirmarContraseña" placeholder="Confirmar contraseña" />
                        <asp:CompareValidator ErrorMessage="* Ambas contraseñas deben ser iguales" ValidationGroup="registro" CssClass="validar" ControlToCompare="txtContraseña" ControlToValidate="txtConfirmarContraseña" runat="server" />
                    </div>
                    <asp:Button Text="Registrame" ValidationGroup="registro" runat="server" ID="btnRegistrarme" OnClick="btnRegistrarme_Click" CssClass="btn btn-success" />
                    <p class="text-center mt-3">¿Ya tienes una cuenta? <a href="Login.aspx">Inicia sesión</a></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
