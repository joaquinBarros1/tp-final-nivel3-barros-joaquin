using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Configuration;

namespace AccesoDatos
{
    public class Datos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }


        public Datos()
        {
            conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearProcedimiento(string procedimientoSP)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedimientoSP;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void setearParametro(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }

        public void actualizar(Usuario usuario)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearConsulta("update USERS set urlImagenPerfil = @imagenPerfil, nombre = @nombre, apellido = @apellido where Id = @Id");
                datos.setearParametro("@Id", usuario.Id);
                datos.setearParametro("@imagenPerfil", (object)usuario.ImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.ejecutarAccion();
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
    }
}

