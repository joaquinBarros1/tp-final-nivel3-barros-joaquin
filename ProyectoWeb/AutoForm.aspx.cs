using dominio;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoWeb
{
    public partial class AutoForm : System.Web.UI.Page
    {
        public bool confirmarEliminar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaDatos categoriaDatos = new CategoriaDatos();
                MarcaDatos marcaDatos = new MarcaDatos();
                List<Marca> marcas = marcaDatos.listar();
                List<Categoria> categorias = categoriaDatos.listar();
                try
                {
                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                ArticuloDatos articuloDatos = new ArticuloDatos();
                Articulo actual = (articuloDatos.listar(id)[0]);
                tbNombre.Text = actual.Nombre;
                tbCodigo.Text = actual.Codigo;
                tbDescripcion.Text = actual.Descripcion;
                tbPrecio.Text = actual.Precio.ToString();
                tbUrl.Text = actual.Img;
                tbId.Text = actual.Id.ToString();
                ddlMarca.SelectedValue = actual.Marca.Id.ToString();
                ddlCategoria.SelectedValue = actual.Categoria.Id.ToString();
                tbId.Visible = true;
                lblId.Visible = true;
                tbId.Enabled = false;
                imageFoto.ImageUrl = tbUrl.Text;
                imageFoto.DataBind();
            }
            if (Request.QueryString["Id"] == null)
            {
                btnEliminar.Enabled = false;
                tbId.Visible = false;
                lblId.Visible = false;
                if (!IsPostBack)
                {
                    ddlMarca.Items.Insert(0, new ListItem("-Seleccione Marca-", ""));
                    ddlMarca.SelectedIndex = 0;
                    ddlCategoria.Items.Insert(0, new ListItem("-Seleccione Categoria-", ""));
                    ddlCategoria.SelectedIndex = 0;
                }
            }

            if (imageFoto.ImageUrl == null)
            {
                imageFoto.Visible = false;
            }

            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                tbCodigo.Enabled = false;
                tbDescripcion.Enabled = false;
                tbNombre.Enabled = false;
                tbUrl.Visible = false;
                tbPrecio.Enabled = false;
                btnAceptar.Visible = false;
                btnEliminar.Visible = false;
                ddlCategoria.Enabled = false;
                ddlMarca.Enabled = false;
                lblImg.Visible = false;

            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo aux = new Articulo();

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }


                if (Request.QueryString["Id"] != null)
                    aux.Id = int.Parse(tbId.Text);
                aux.Nombre = tbNombre.Text;
                aux.Descripcion = tbDescripcion.Text;
                aux.Precio = decimal.Parse(tbPrecio.Text);
                aux.Codigo = tbCodigo.Text;
                aux.Marca = new Marca();
                aux.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                aux.Categoria = new Categoria();
                aux.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                aux.Img = tbUrl.Text;
                ArticuloDatos articuloDatos = new ArticuloDatos();
                if (Validaciones.validaTextoVacio(tbCodigo) || Validaciones.validaTextoVacio(tbNombre) || Validaciones.validaTextoVacio(tbPrecio) || ddlCategoria.SelectedValue != "" || ddlMarca.SelectedValue != "")
                {
                    if (Request.QueryString["Id"] != null)
                        articuloDatos.modificarConSP(aux);
                    else
                        articuloDatos.agregarConSP(aux);
                    Response.Redirect("ArticulosTabla.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloDatos articuloDatos = new ArticuloDatos();
            try
            {
                int id = int.Parse(tbId.Text);
                articuloDatos.eliminarConSP(id);
                Response.Redirect("ArticulosTabla.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void tbUrl_TextChanged(object sender, EventArgs e)
        {
            imageFoto.ImageUrl = tbUrl.Text;
            imageFoto.DataBind();
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminar = true;
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            try
            {
                if (!datos.buscarFavorito(((Usuario)Session["usuario"]).Id, int.Parse(tbId.Text)))
                {
                    datos.agregarFavoritos((Usuario)Session["usuario"], int.Parse(tbId.Text));
                }
                else
                {
                    lblValidarFav.Text = " Este artículo ya se encuentra en tus favoritos";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}