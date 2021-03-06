USE [master]
GO
/****** Object:  Database [dbpawprints]    Script Date: 12/10/2018 1:29:43 PM ******/
CREATE DATABASE [dbpawprints]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbpawprints', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbpawprints.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbpawprints_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbpawprints_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbpawprints] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbpawprints].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbpawprints] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbpawprints] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbpawprints] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbpawprints] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbpawprints] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbpawprints] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [dbpawprints] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbpawprints] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbpawprints] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbpawprints] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbpawprints] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbpawprints] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbpawprints] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbpawprints] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbpawprints] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbpawprints] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbpawprints] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbpawprints] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbpawprints] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbpawprints] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbpawprints] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbpawprints] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbpawprints] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbpawprints] SET  MULTI_USER 
GO
ALTER DATABASE [dbpawprints] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbpawprints] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbpawprints] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbpawprints] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbpawprints] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbpawprints] SET QUERY_STORE = OFF
GO
USE [dbpawprints]
GO
/****** Object:  Table [dbo].[tbl_adopciones]    Script Date: 12/10/2018 1:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_adopciones](
	[IdAdopcion] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [varchar](50) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[Animal] [int] NULL,
	[Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAdopcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_animales]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_animales](
	[IdAnimal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Clase] [varchar](50) NOT NULL,
	[Sexo] [varchar](13) NOT NULL,
	[Edad] [int] NOT NULL,
	[Raza] [varchar](9) NOT NULL,
	[Tamaño] [varchar](100) NOT NULL,
	[FechaNac] [date] NULL,
	[Peso] [varchar](10) NOT NULL,
	[Situacion] [varchar](100) NOT NULL,
	[Color] [varchar](25) NOT NULL,
	[Vacunas] [varchar](25) NOT NULL,
	[Temperamento] [varchar](20) NOT NULL,
	[Especie] [int] NULL,
	[Poblacion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_especies]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_especies](
	[IdEspecie] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_login]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_login](
	[IdLogin] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Pass] [varchar](50) NOT NULL,
	[Rol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_poblacion]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_poblacion](
	[IdPob] [int] IDENTITY(1,1) NOT NULL,
	[Especie] [int] NULL,
	[Cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_reportes]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_reportes](
	[IdReporte] [int] IDENTITY(1,1) NOT NULL,
	[TipoAnimal] [varchar](50) NOT NULL,
	[TipoReporte] [int] NULL,
	[Telefono] [varchar](13) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_roles]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](25) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK__tbl_role__2A49584CE9BF7EDE] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_tipoRep]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tipoRep](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK__tbl_tipo__9E3A29A56A095F3B] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usuarios]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [varchar](13) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Dui] [varchar](10) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Datos] [int] NULL,
 CONSTRAINT [PK__tbl_usua__5B65BF970C2068E8] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_voluntarios]    Script Date: 12/10/2018 1:29:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_voluntarios](
	[IdVoluntario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [int] NULL,
	[Edad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVoluntario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_adopciones]  WITH CHECK ADD FOREIGN KEY([Animal])
REFERENCES [dbo].[tbl_animales] ([IdAnimal])
GO
ALTER TABLE [dbo].[tbl_adopciones]  WITH CHECK ADD  CONSTRAINT [FK__tbl_adopc__Usuar__60A75C0F] FOREIGN KEY([Usuario])
REFERENCES [dbo].[tbl_usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[tbl_adopciones] CHECK CONSTRAINT [FK__tbl_adopc__Usuar__60A75C0F]
GO
ALTER TABLE [dbo].[tbl_animales]  WITH CHECK ADD FOREIGN KEY([Especie])
REFERENCES [dbo].[tbl_especies] ([IdEspecie])
GO
ALTER TABLE [dbo].[tbl_animales]  WITH CHECK ADD FOREIGN KEY([Poblacion])
REFERENCES [dbo].[tbl_poblacion] ([IdPob])
GO
ALTER TABLE [dbo].[tbl_login]  WITH CHECK ADD  CONSTRAINT [FK__tbl_login__Rol__5BE2A6F2] FOREIGN KEY([Rol])
REFERENCES [dbo].[tbl_roles] ([IdRol])
GO
ALTER TABLE [dbo].[tbl_login] CHECK CONSTRAINT [FK__tbl_login__Rol__5BE2A6F2]
GO
ALTER TABLE [dbo].[tbl_poblacion]  WITH CHECK ADD FOREIGN KEY([Especie])
REFERENCES [dbo].[tbl_especies] ([IdEspecie])
GO
ALTER TABLE [dbo].[tbl_reportes]  WITH CHECK ADD  CONSTRAINT [FK__tbl_repor__TipoR__619B8048] FOREIGN KEY([TipoReporte])
REFERENCES [dbo].[tbl_tipoRep] ([IdTipo])
GO
ALTER TABLE [dbo].[tbl_reportes] CHECK CONSTRAINT [FK__tbl_repor__TipoR__619B8048]
GO
ALTER TABLE [dbo].[tbl_usuarios]  WITH CHECK ADD  CONSTRAINT [FK__tbl_usuar__Datos__5AEE82B9] FOREIGN KEY([Datos])
REFERENCES [dbo].[tbl_login] ([IdLogin])
GO
ALTER TABLE [dbo].[tbl_usuarios] CHECK CONSTRAINT [FK__tbl_usuar__Datos__5AEE82B9]
GO
ALTER TABLE [dbo].[tbl_voluntarios]  WITH CHECK ADD  CONSTRAINT [FK__tbl_volun__Usuar__5EBF139D] FOREIGN KEY([Usuario])
REFERENCES [dbo].[tbl_usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[tbl_voluntarios] CHECK CONSTRAINT [FK__tbl_volun__Usuar__5EBF139D]
GO
USE [master]
GO
ALTER DATABASE [dbpawprints] SET  READ_WRITE 
GO
