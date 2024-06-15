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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            Usuario usuario;
            UsuarioDatos datos = new UsuarioDatos();
            try
            {
                if (Validaciones.validaTextoVacio(txtEmail) || Validaciones.validaTextoVacio(txtEmail))
                {
                    usuario = new Usuario(txtEmail.Text, txtContraseña.Text, false);
                    if (datos.Loguear(usuario) != null)
                    {
                        Session.Add("usuario", datos.Loguear(usuario));
                        Response.Redirect("default.aspx", false);
                    }
                    else
                    {
                        lblLogin.Text = "* Usuario o contraseña incorrectos, intentalo denuevo";
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}