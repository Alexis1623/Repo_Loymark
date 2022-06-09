create database BD_Loymark

create table Usuarios ( 

ID int IDENTITY(1000,1) NOT NULL,
Nombre char(15) Not NULL ,
Apellido char(15) Not NULL ,
Correo varchar(25) Not NULL ,
Fecha_Nacimiento Date Not NULL ,
Telefono int Not NULL ,
Pais_R char(25) Not NULL ,
Info bit Not NULL ,
Usuario varchar(50) NULL,
Contrasenia varbinary(500) NULL

)
 Go


 use BD_Loymark 
create table Imagenes (

ID_User int  ,
Imagen Image
)

GO

 use BD_Loymark 
create table Actividades (

ID_Actividad int IDENTITY(3000,1) NOT NULL,
Create_date date,
ID_user char(15) Not NULL ,
Actividad varchar(250)
)

GO
--Procedimiento almacenado para registrar
Create procedure Registroo
@Nombre varchar(15),
@Apellido varchar(15),
@Correo varchar(25),
@Fecha_Nacimiento date,
@Telefono int,
@Pais_R varchar(25),
@Info bit,
@Usuario varchar(50),
@Contrasenia varchar(500),
@Patron varchar(50),
@ID_User varchar(15),
@Imagen image,
@C_date date,
@Actividad varchar(100)
as
begin 
--insertar y encriptar
insert into Usuarios values (@Nombre, @Apellido,@Correo, @Fecha_Nacimiento, @Telefono, @Pais_R,@Info,@Usuario, ENCRYPTBYPASSPHRASE(@Patron, @Contrasenia))
--Se obtiene el id y se agrega la  imagen de perfil a la tabla de imagenes
set @ID_User = (SELECT ID FROM Usuarios  where Usuario = @Usuario)
insert  into Imagenes values (@ID_User,  @Imagen)
--Se obtiene el id y se agrega a la tabla de actividades
set @ID_User = (SELECT ID FROM Usuarios  where Usuario = @Usuario)
insert  into Actividades values (@C_date,@ID_User, @Actividad)
end

--Validar datos(si existe o no dentro de la base de datos
create procedure Validar
@Usuario varchar(50),
@Contrasenia varchar(50),
@Patron varchar(50)
as
begin
select * from Usuarios where Usuario=@Usuario and CONVERT(varchar(50),DECRYPTBYPASSPHRASE(@Patron, Contrasenia))=@Contrasenia
end
GO

--Obtener datos del perfil de Usuario
create procedure Perfil
@ID int
as 
begin
Select * from Usuarios where ID = @ID
Select * from Imagenes where ID_User = @ID
END



create procedure ContarUsuario
@usuario varchar(50)
as
begin

select count(*) from Usuarios where Usuario=@usuario
end
GO

--Eliminar usuario
create procedure Eliminar_User
@ID int 
as 
begin
delete from Usuarios where ID = @ID
delete from Imagenes where ID_User = @ID
end

--Cambiar contraseña
create procedure Cambiar_Contrasenia
@id int,
@Contrasenia varchar(500),
@Patron varchar(50),
@ID_User varchar(15),
@C_date date,
@Actividad varchar(100)
as
begin
update Usuarios set Contrasenia=(ENCRYPTBYPASSPHRASE(@Patron, @Contrasenia)) where Id=@id
insert  into Actividades values (@C_date,@ID_User, @Actividad)
end
GO

--Cambiar Imagen
create procedure CambiarImagen
@Id int,
@Imagen image
as
begin
update Imagenes set Imagen=@Imagen where ID_User=@Id
end
GO

Select * From Usuarios
Select * From Imagenes
Select * from Actividades

Delete  From Usuarios
Delete  From Imagenes
Delete  from Actividades



 