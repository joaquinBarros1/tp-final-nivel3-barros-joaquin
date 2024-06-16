<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AutoForm.aspx.cs" Inherits="ProyectoWeb.AutoForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar {
            color: red;
            font-size: 16px;
        }

        .margen {
            margin-top: 8px;
        }
    </style>

    <script>
        function confirmarEliminacion() {
            if (confirm("¿Está seguro que desea eliminar el artículo?"))
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="scripManager1" />
    <div class="row">
        <div class="col-6">
            <div>
                <asp:Label runat="server" ID="lblId" for="tbId" class="form-label">ID</asp:Label>
                <asp:TextBox runat="server" ID="tbId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="tbNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="tbNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="* Campo obligatorio" CssClass="validar" ControlToValidate="tbNombre" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="* Máximo 50 caracteres" CssClass="validar" ValidationExpression="^.{0,50}$" ControlToValidate="tbNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="tbCodigo" class="form-label">Código</label>
                <asp:TextBox runat="server" ID="tbCodigo" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="* Campo obligatorio" CssClass="validar" ControlToValidate="tbCodigo" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="* Máximo 50 caracteres" CssClass="validar" ValidationExpression="^.{0,50}$" ControlToValidate="tbCodigo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="tbDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine" CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="* Máximo 150 caracteres" CssClass="validar" ValidationExpression="^.{0,150}$" ControlToValidate="tbDescripcion" runat="server" />
            </div>
            <div class="mb-3">
                <label for="tbPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="tbPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="* Campo obligatorio" CssClass="validar" ControlToValidate="tbPrecio" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="* Únicamente caracteres númericos" CssClass="validar" ValidationExpression="^^[0-9.,]+$" ControlToValidate="tbPrecio" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" />
                <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="ddlMarca"
                    InitialValue="" ErrorMessage="* Debe seleccionar una opción." CssClass="validar" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoria" ErrorMessage="* Debe seleccionar una opción." CssClass="validar" InitialValue="" ControlToValidate="ddlCategoria" runat="server" />
            </div>
            <div class="col-3">
                <asp:Button Text="Añadir Favorito" CssClass="btn btn-success" ID="btnFavoritos" OnClick="btnFavoritos_Click" runat="server" />
                <asp:Label runat="server" class="validar" ID="lblValidarFav" />
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="tbUrl" id="lblImg" class="form-label" runat="server">Imágen URL</label>
                        <asp:TextBox runat="server" ID="tbUrl" AutoPostBack="true" OnTextChanged="tbUrl_TextChanged" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:Image runat="server" ID="imageFoto" Width="250px" Height="250px" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3">
                <div class="col-3">
                    <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnAceptar" OnClientClick="return validar()" OnClick="btnAceptar_Click" runat="server" />
                </div>

                <div class="col-3" style="margin-top: 10px">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Button Text="Eliminar" CssClass="btn btn-danger margen" ID="btnEliminar" OnClientClick="return confirmarEliminacion()" OnClick="btnEliminar_Click" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <span>
                <a href="ArticulosTabla.aspx" class="btn btn-warning">Volver</a>
            </span>

        </div>
    </div>

</asp:Content>
