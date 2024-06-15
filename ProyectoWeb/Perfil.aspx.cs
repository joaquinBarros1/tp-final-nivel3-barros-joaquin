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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["usuario"] != null && !IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                txtEmail.Text = usuario.Email;
                txtApellido.Text = usuario.Apellido;
                txtNombre.Text = usuario.Nombre;
                imgNuevoPerfil.ImageUrl = "./images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(!Page.IsValid)
            {
                return;
            }
            try
            {
                Datos datos = new Datos();
                Usuario usuario = (Usuario)Session["usuario"];
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                datos.actualizar(usuario);
                Image image = (Image)Master.FindControl("imgAvatar");
                image.ImageUrl = "~/images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                imgNuevoPerfil.ImageUrl = "./images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}