--Crea base de datos
create database LocalChurch
--Comando para eliminar(drop database YouGym)

create table USUARIO(
Id varchar(12) primary key not null,
Codigo_Usuario nvarchar(10) not null,
Tipo_De_Id char(2)not null,
Nombres varchar(30) not null,
Apellidos varchar(30) not null,
Fecha_De_Nacimiento datetime not null,
Edad int,
Sexo varchar(5),
Direccion_Domicilio text,
Telefono varchar(15),
Rol varchar(15),
Correo varchar(100),
NombreUsuario nvarchar(50),
Contraseña nvarchar(50)
);
create table SOFTWARE(
Nombre_De_Software varchar(30) primary key not null,
Fecha_De_Instalacion datetime not null,
Fecha_De_Expiracion varchar(12) not null,
Hora_De_Expiracion varchar(15) not null,
Fecha_De_Activacion varchar(12) not null,
Hora_De_Activacion varchar(15) not null,
Estado_De_Licencia varchar(10) not null,
);
create table LICENCIA(
Licencia nvarchar(30) not null
);
create table IGLESIA(
Id_Iglesia nvarchar(6) primary key not null,
Nombre_De_Iglesia nvarchar(100)not null,
NIT nvarchar(50)not null,
Numero_De_Iglesia text,
PBX nvarchar(30),
Direccion nvarchar(100),
Telefono varchar(15)
);