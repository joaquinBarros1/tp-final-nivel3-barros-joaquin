<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosFavoritos.aspx.cs" Inherits="ProyectoWeb.ArticulosFavoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <asp:GridView runat="server" DataKeyNames="Id" ID="dgvFavoritos" CssClass="table table-dark" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvFavoritos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:TemplateField HeaderText="Imagen">
                        <ItemTemplate>
                            <img src="<%# Eval("Img") %>" id="imgDgv" onerror="imgError(this)" height="150" width="125" ControlStyle-Height="150px" ControlStyle-Width="125px" alt="Artículo" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Eliminar Favorito" />
                </Columns>
            </asp:GridView>
            <a href="ArticulosTabla.aspx" class="btn btn-primary">Ir al catálogo</a>
</asp:Content>
