using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using AccesoDatos;

namespace ProyectoWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)

        {
            filtroAvanzado = chkFiltroAvanzado.Checked;
            ArticuloDatos datos = new ArticuloDatos();
            if (Session["listaArticulos"] == null && Session["listaMarca"] == null && Session["listaCategoria"] == null)
            {
                CategoriaDatos categoriaDatos = new CategoriaDatos();
                MarcaDatos marcaDatos = new MarcaDatos();
                Session.Add("listaArticulos", datos.listarConSP());
                Session.Add("listaMarca", marcaDatos.listar());
                Session.Add("listaCategoria", categoriaDatos.listar());
            }

            try
            {
                List<Articulo> listaArticulos = datos.listarConSP();
                Session.Add("listaArticulos", listaArticulos);
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvArticulos.SelectedDataKey.Value.ToString());
            Response.Redirect("AutoForm.aspx?Id=" + id);

        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> listaFiltrada = ((List<Articulo>)Session["listaArticulos"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chkFiltroAvanzado.Checked;
            txtFiltro.Enabled = !filtroAvanzado;
            lblEnter.Visible = !filtroAvanzado;
        }

        protected void ddlCaracteristica_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            string criterio = ddlCaracteristica.SelectedItem.ToString();
            if (criterio == "Nombre" || criterio == "Marca" || criterio == "Categoria" || criterio == "Descripcion" || criterio == "Codigo")
            {
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
            else
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }

        }

        protected void btnBuscarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            ArticuloDatos articuloDatos = new ArticuloDatos();
            try
            {
                string caracteristica = ddlCaracteristica.SelectedItem.ToString();
                string criterio = ddlCriterio.SelectedItem.ToString();
                string busqueda = txtBuscar.Text;
                dgvArticulos.DataSource = articuloDatos.buscar(caracteristica, criterio, busqueda);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            ArticuloDatos articulodatos = new ArticuloDatos();
            try
            {
                ddlCaracteristica.SelectedIndex = 0;
                ddlCriterio.Items.Clear();
                txtBuscar.Text = null;
                dgvArticulos.DataSource = articulodatos.listarConSP();
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}