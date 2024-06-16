<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosTabla.aspx.cs" Inherits="ProyectoWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar {
            color: red;
            font-size: 14px;
        }

        .margen {
            margin-left: 8px;
            font-size: 18px;
        }

        .pagination {
            justify-content: center;
            display: flex;
        }

            .pagination a {
                margin: 0 5px;
                padding: 5px 10px;
                border-radius: 5px;
                border: 1px solid #dee2e6;
                color: #007bff;
                text-decoration: none;
            }

                .pagination a:hover {
                    background-color: #007bff;
                    color: white;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" placeholder="Filtrar por nombre"></asp:TextBox>
                <label for="txtFiltro" id="lblEnter" runat="server" style="font-size: 16px; color: gray">Presiona enter para buscar</label>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="chkFiltroAvanzado" class="margen">Filtro avanzado</label>
                <asp:CheckBox Text="" ID="chkFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
            </div>
        </div>
    </div>
    <%if (chkFiltroAvanzado.Checked)
        {%>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <label for="ddlCaracteristica">Filtrar por:</label>
                <asp:DropDownList runat="server" ID="ddlCaracteristica" OnSelectedIndexChanged="ddlCaracteristica_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                    <asp:ListItem Selected="true" hidden="true"></asp:ListItem>
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Descripcion" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                    <asp:ListItem Text="Codigo" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="* Selecciona la Caracteristica" CssClass="validar" ValidationGroup="filtroAvanzado" ControlToValidate="ddlCaracteristica" runat="server" />
            </div>
        </div>
        <div class="col-3">
            <label for="ddlCriterio">Criterio: </label>
            <div class="mb-3">
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="* Selecciona criterio" CssClass="validar" ValidationGroup="filtroAvanzado" ControlToValidate="ddlCriterio" runat="server" />
            </div>
        </div>
        <div class="col-3">
            <label for="txtBuscar">Parámetro: </label>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" />
                <%if (ddlCaracteristica.Text == "Precio")
                    {%>
                <asp:RequiredFieldValidator ErrorMessage="* Escribe el parámetro" ValidationGroup="filtroAvanzado" CssClass="validar" ControlToValidate="txtBuscar" runat="server" />
                <%} %>
            </div>
        </div>
    </div>
    <div class="mb-3">
        <div style="margin-bottom: 10px;">
            <asp:Button Text="Buscar" ID="btnBuscarFiltroAvanzado" ValidationGroup="filtroAvanzado" OnClick="btnBuscarFiltroAvanzado_Click" CssClass="btn btn-primary" runat="server" />
            <asp:Button Text="Limpiar Filtro" ID="btnLimpiarFiltro" OnClick="btnLimpiarFiltro_Click" CssClass="btn btn-primary" runat="server" />
        </div>
    </div>

    <%}



    %>
    <div class="row">
        <div class="col">
            <asp:GridView runat="server" DataKeyNames="Id" ID="dgvArticulos" CssClass="table table-dark" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:TemplateField HeaderText="Imagen">
                        <ItemTemplate>
                            <img src="<%# Eval("Img") %>" id="imgDgv" onerror="imgError(this)" height="150" width="125" controlstyle-height="150px" controlstyle-width="125px" alt="Artículo" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:CommandField HeaderText="Ver Detalle" ShowSelectButton="true" ControlStyle-CssClass="btn btn-warning" SelectText="Ver detalle" />
                </Columns>
            </asp:GridView>
            <%if (AccesoDatos.Seguridad.esAdmin(Session["usuario"]))
                {%>
            <div>
                <a href="AutoForm.aspx" class="btn btn-success">Agregar Artículo</a>
            </div>
            <%} %>
        </div>
    </div>
</asp:Content>
