using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace AccesoDatos
{
    public class ArticuloDatos
    {

        public List<Articulo> listar(string id = "")
        {
            Datos datos = new Datos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion as Descripcion, IdMarca, IdCategoria , M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdCategoria = C.Id and A.IdMarca = M.Id and A.Id = @id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Img = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Articulo> listarConSP()
        {
            Datos datos = new Datos();
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                //string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion as Descripcion, IdMarca, IdCategoria , M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdCategoria = C.Id and A.IdMarca = M.Id";
                //datos.setearConsulta(consulta);
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Img = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    articulos.Add(aux);
                }
                return articulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificar(Articulo modificar)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @Marca, IdCategoria = @Categoria, ImagenUrl = @UrlImagen, Precio = @Precio where Id = @Id");
                datos.setearParametro("@Codigo", modificar.Codigo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Descripcion", modificar.Descripcion);
                datos.setearParametro("@Marca", modificar.Marca.Id);
                datos.setearParametro("@Categoria", modificar.Categoria.Id);
                datos.setearParametro("@UrlImagen", modificar.Img);
                datos.setearParametro("@Precio", modificar.Precio);
                datos.setearParametro("@Id", modificar.Id);

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

        public void modificarConSP(Articulo modificar)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearProcedimiento("storedModificarArticulo");
                datos.setearParametro("@Codigo", modificar.Codigo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Descripcion", modificar.Descripcion);
                datos.setearParametro("@Marca", modificar.Marca.Id);
                datos.setearParametro("@Categoria", modificar.Categoria.Id);
                datos.setearParametro("@UrlImagen", modificar.Img);
                datos.setearParametro("@Precio", modificar.Precio);
                datos.setearParametro("@Id", modificar.Id);
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

        public void agregar(Articulo nuevo)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS values (@Codigo, @Nombre, @Descripcion, @Marca, @Categoria, @UrlImagen, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Marca", nuevo.Marca.Id);
                datos.setearParametro("@Categoria", nuevo.Categoria.Id);
                datos.setearParametro("@UrlImagen", nuevo.Img);
                datos.setearParametro("@Precio", nuevo.Precio);

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

        public void agregarConSP(Articulo nuevo)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearProcedimiento("storedAltaArticulo");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Marca", nuevo.Marca.Id);
                datos.setearParametro("@Categoria", nuevo.Categoria.Id);
                datos.setearParametro("@UrlImagen", nuevo.Img);
                datos.setearParametro("@Precio", nuevo.Precio);

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

        public void eliminarConSP(int id)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearProcedimiento("storedEliminar");
                datos.setearParametro("@Id", id);
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

        public List<Articulo> buscar(string Caracteristica, string Criterio, string Busqueda)
        {
            Datos datos = new Datos();
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion as Descripcion, IdMarca, IdCategoria , M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdCategoria = C.Id and A.IdMarca = M.Id and ";
                if (Caracteristica == "Nombre")
                {
                    switch (Criterio)
                    {
                        case "Empieza con":
                            consulta += "Nombre like '" + Busqueda + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + Busqueda + "'";
                            break;
                        case "Contiene":
                            consulta += "Nombre like '%" + Busqueda + "%'";
                            break;
                    }
                }
                if (Caracteristica == "Codigo")
                {
                    switch (Criterio)
                    {
                        case "Empieza con":
                            consulta += "Codigo like'" + Busqueda + "%'";
                            break;
                        case "Termina con":
                            consulta += "Codigo like '%" + Busqueda + "'";
                            break;
                        case "Contiene":
                            consulta += "Codigo like '%" + Busqueda + "%'";
                            break;
                    }
                }
                if (Caracteristica == "Marca")
                {
                    switch (Criterio)
                    {
                        case "Empieza con":
                            consulta += "M.Descripcion like '" + Busqueda + "%'";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + Busqueda + "'";
                            break;
                        case "Contiene":
                            consulta += "M.Descripcion like '%" + Busqueda + "%'";
                            break;
                    }
                }
                if (Caracteristica == "Categoria")
                {
                    switch (Criterio)
                    {
                        case "Empieza con":
                            consulta += "C.Descripcion like '" + Busqueda + "%'";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + Busqueda + "'";
                            break;
                        case "Contiene":
                            consulta += "C.Descripcion like '%" + Busqueda + "%'";
                            break;
                    }
                }
                if (Caracteristica == "Descripcion")
                {
                    switch (Criterio)
                    {
                        case "Empieza con":
                            consulta += "A.Descripcion like '" + Busqueda + "%'";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + Busqueda + "'";
                            break;
                        case "Contiene":
                            consulta += "A.Descripcion like '%" + Busqueda + "%'";
                            break;
                    }
                }
                if (Caracteristica == "Precio")
                {
                    switch (Criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + Busqueda;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + Busqueda;
                            break;
                        case "Igual a":
                            consulta += "Precio = " + Busqueda;
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Img = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    articulos.Add(aux);
                }
                return articulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar(int id)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", id);
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

        public void agregarFavoritos(Usuario Usuario, int Articulo)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearConsulta("insert into FAVORITOS values (@Usuario, @Articulo)");
                datos.setearParametro("@Usuario", Usuario.Id);
                datos.setearParametro("@Articulo", Articulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool buscarFavorito(int UsuarioId, int ArticuloId)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearConsulta("select IdArticulo from FAVORITOS where IdUser = @usuario and IdArticulo = @articulo");
                datos.setearParametro("@usuario", UsuarioId);
                datos.setearParametro("@articulo", ArticuloId);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    if (ArticuloId == (int)datos.Lector["IdArticulo"])
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> listarFavoritos(Usuario usuario)
        {
            Datos datos = new Datos();
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion as Descripcion, IdMarca, IdCategoria , M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C, FAVORITOS F where A.IdCategoria = C.Id and A.IdMarca = M.Id and F.IdArticulo = A.Id and F.IdUser = @Usuario");
                datos.setearParametro("@Usuario", usuario.Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Img = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    articulos.Add(aux);
                }
                return articulos;
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

        public void eliminarFavorito(int Articulo)
        {
            Datos datos = new Datos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where IdArticulo = @Articulo");
                datos.setearParametro("@Articulo", Articulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}

