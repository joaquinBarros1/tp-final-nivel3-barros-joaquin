using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace AccesoDatos
{
    public class UsuarioDatos
    {
        public Usuario Loguear(Usuario usuario)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearConsulta("Select id, urlImagenPerfil, nombre, apellido, admin from USERS where email = @email AND pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["admin"] is DBNull))
                        usuario.TipoUsuario = (bool)datos.Lector["admin"];
                    return usuario;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int RegistrarNuevo(Usuario nuevo)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearProcedimiento("insertarRegistro");
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Password", nuevo.Password);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            Datos datos = new Datos();

            try
            {
                datos.setearConsulta("select email, pass from USERS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["Id"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool buscarUsuario(string email)
        {
            Datos datos = new Datos();
            Usuario usuario = new Usuario();

            try
            {
                datos.setearConsulta("select email from USERS where email = @email");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.Email = (string)datos.Lector["email"];
                }
                if (!(usuario.Email == email))
                    return true;
                else return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
