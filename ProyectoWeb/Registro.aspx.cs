using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using AccesoDatos;
using System.Runtime.InteropServices;

namespace ProyectoWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarme_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }

            Usuario usuario = new Usuario(txtEmail.Text, txtContraseña.Text, false);
            UsuarioDatos datos = new UsuarioDatos();
            try
            {
                if (datos.buscarUsuario(usuario.Email))
                {
                    usuario.Id = datos.RegistrarNuevo(usuario);
                    Session.Add("usuario", usuario);
                }
                else
                {
                    lblEmail.Text = "* Ya existe un usuario registrado con ese Email";
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}