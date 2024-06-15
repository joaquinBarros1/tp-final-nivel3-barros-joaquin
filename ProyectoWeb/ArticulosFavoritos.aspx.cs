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
    public partial class ArticulosFavoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloDatos datos = new ArticuloDatos();
                try
                {
                    if ((Usuario)Session["usuario"] != null)
                    {
                        dgvFavoritos.DataSource = datos.listarFavoritos((Usuario)Session["usuario"]);
                        dgvFavoritos.DataBind();
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            try
            {
                int id = int.Parse(dgvFavoritos.SelectedDataKey.Value.ToString());
                datos.eliminarFavorito(id);
                dgvFavoritos.DataSource = datos.listarFavoritos((Usuario)Session["usuario"]);
                dgvFavoritos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}