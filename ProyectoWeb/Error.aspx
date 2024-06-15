<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ProyectoWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ha ocurrido un error!</h1>
    <asp:Label Text="" ID="lblError" runat="server"></asp:Label>
    <asp:Button Text="Inicio" CssClass="btn btn-primary" runat="server" ID="btnVolver" OnClick="btnVolver_Click" />
</asp:Content>
