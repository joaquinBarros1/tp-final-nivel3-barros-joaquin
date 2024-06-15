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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Login || Page is Registro || Page is Error || Page is _default || Page is Nosotros))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }

            if((Page is Login || Page is Registro))
            {
                bodyMaster.Attributes.Add("class", "bg-dark");
            }

            if (Seguridad.sesionActiva(Session["usuario"]) &&  !(string.IsNullOrEmpty(((Usuario)Session["usuario"]).ImagenPerfil)))
            {
                imgAvatar.ImageUrl = "~/images/" + ((Usuario)Session["usuario"]).ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
            }
            else
            {
                imgAvatar.ImageUrl = "https://static.vecteezy.com/system/resources/thumbnails/009/734/569/small/default-avatar-profile-icon-social-media-user-photo-vector.jpg";
            }
        }

        protected void btnRegistarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArticulosFavoritos.aspx", false);
        }
    }
}