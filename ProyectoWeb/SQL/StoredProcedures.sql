USE[CATALOGO_WEB_DB]
GO

create procedure[dbo].[insertarRegistro]
@Email varchar(100),
@Password varchar(20)
as
insert into USERS(email, pass, admin) output inserted.Id values(@Email, @Password, 0)
GO

create procedure[dbo].[storedAltaArticulo]
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(150),
@Marca int,
@Categoria int,
@UrlImagen varchar(1000),
@Precio money as insert into ARTICULOS values(@Codigo, @Nombre, @Descripcion, @Marca, @Categoria, @UrlImagen, @Precio)
GO

create procedure[dbo].[storedEliminar]
@Id int
as
delete from ARTICULOS where Id = @Id
GO

create procedure[dbo].[storedListar] as
Select A.Id, Codigo, Nombre, A.Descripcion as Descripcion, IdMarca, IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdCategoria = C.Id and A.IdMarca = M.Id
GO

create procedure[dbo].[storedModificarArticulo]
@Id int,
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(150),
@Marca int,
@Categoria int,
@UrlImagen varchar(1000),
@Precio money as update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @Marca, IdCategoria = @Categoria, ImagenUrl = @UrlImagen, Precio = @Precio where Id = @Id
GO