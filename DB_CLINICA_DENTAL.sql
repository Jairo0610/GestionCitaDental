USE [master]
GO
/****** Object:  Database [db_clinica_dental]    Script Date: 22/11/2024 21:36:39 ******/
CREATE DATABASE [db_clinica_dental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_clinica_dental', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\db_clinica_dental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_clinica_dental_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\db_clinica_dental_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_clinica_dental] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_clinica_dental].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_clinica_dental] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_clinica_dental] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_clinica_dental] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_clinica_dental] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_clinica_dental] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_clinica_dental] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_clinica_dental] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_clinica_dental] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_clinica_dental] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_clinica_dental] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_clinica_dental] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_clinica_dental] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_clinica_dental] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_clinica_dental] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_clinica_dental] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_clinica_dental] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_clinica_dental] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_clinica_dental] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_clinica_dental] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_clinica_dental] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_clinica_dental] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_clinica_dental] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_clinica_dental] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_clinica_dental] SET  MULTI_USER 
GO
ALTER DATABASE [db_clinica_dental] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_clinica_dental] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_clinica_dental] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_clinica_dental] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_clinica_dental] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_clinica_dental] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_clinica_dental] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_clinica_dental] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_clinica_dental]
GO
/****** Object:  Table [dbo].[tblCita]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCita](
	[idCita] [int] IDENTITY(1,1) NOT NULL,
	[idPaciente] [int] NULL,
	[idProcedimiento] [int] NULL,
	[idOdontologo] [int] NULL,
	[idEstadoCita] [int] NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCorreo]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCorreo](
	[idCorreo] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCorreo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDisponibilidad]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDisponibilidad](
	[idDisponibilidad] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDisponibilidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEstadoCita]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEstadoCita](
	[idEstadoCita] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstadoCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOdontologo]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOdontologo](
	[idOdontologo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Telefono] [nvarchar](10) NULL,
	[idCorreo] [int] NULL,
	[idDisponible] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idOdontologo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPaciente]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPaciente](
	[idPaciente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[DUI] [nvarchar](9) NOT NULL,
	[idCorreo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProcedimiento]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProcedimiento](
	[idProcedimiento] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Costo] [float] NOT NULL,
	[Duracion] [time](0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProcedimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTipoUsuario]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTipoUsuario](
	[idTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsuario]    Script Date: 22/11/2024 21:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](100) NOT NULL,
	[Contraseña] [nvarchar](100) NOT NULL,
	[idCorreo] [int] NOT NULL,
	[idTipoUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCita] ON 

INSERT [dbo].[tblCita] ([idCita], [idPaciente], [idProcedimiento], [idOdontologo], [idEstadoCita], [Fecha]) VALUES (8, 2, 2, 1, 1, CAST(N'2024-11-30T13:00:00.000' AS DateTime))
INSERT [dbo].[tblCita] ([idCita], [idPaciente], [idProcedimiento], [idOdontologo], [idEstadoCita], [Fecha]) VALUES (9, 2, 3, 7, 1, CAST(N'2024-11-30T07:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tblCita] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCorreo] ON 

INSERT [dbo].[tblCorreo] ([idCorreo], [Correo]) VALUES (1, N'odontologo1@clinicadental.com')
INSERT [dbo].[tblCorreo] ([idCorreo], [Correo]) VALUES (2, N'paciente1@correo.com')
INSERT [dbo].[tblCorreo] ([idCorreo], [Correo]) VALUES (3, N'admin@clinicadental.com')
INSERT [dbo].[tblCorreo] ([idCorreo], [Correo]) VALUES (4, N'jose@gmail.com')
INSERT [dbo].[tblCorreo] ([idCorreo], [Correo]) VALUES (5, N'joseperez@gmail.com')
SET IDENTITY_INSERT [dbo].[tblCorreo] OFF
GO
SET IDENTITY_INSERT [dbo].[tblDisponibilidad] ON 

INSERT [dbo].[tblDisponibilidad] ([idDisponibilidad], [Descripcion]) VALUES (1, N'Disponible')
INSERT [dbo].[tblDisponibilidad] ([idDisponibilidad], [Descripcion]) VALUES (2, N'No disponible')
SET IDENTITY_INSERT [dbo].[tblDisponibilidad] OFF
GO
SET IDENTITY_INSERT [dbo].[tblEstadoCita] ON 

INSERT [dbo].[tblEstadoCita] ([idEstadoCita], [Descripcion]) VALUES (1, N'Programada')
INSERT [dbo].[tblEstadoCita] ([idEstadoCita], [Descripcion]) VALUES (2, N'Realizada')
INSERT [dbo].[tblEstadoCita] ([idEstadoCita], [Descripcion]) VALUES (3, N'Cancelada')
SET IDENTITY_INSERT [dbo].[tblEstadoCita] OFF
GO
SET IDENTITY_INSERT [dbo].[tblOdontologo] ON 

INSERT [dbo].[tblOdontologo] ([idOdontologo], [Nombre], [Telefono], [idCorreo], [idDisponible]) VALUES (1, N'Dr. Juan Gomez', N'4856-4844', 1, 1)
INSERT [dbo].[tblOdontologo] ([idOdontologo], [Nombre], [Telefono], [idCorreo], [idDisponible]) VALUES (7, N'Dr. Jose Perez', N'7895-5987', 5, 1)
SET IDENTITY_INSERT [dbo].[tblOdontologo] OFF
GO
SET IDENTITY_INSERT [dbo].[tblPaciente] ON 

INSERT [dbo].[tblPaciente] ([idPaciente], [Nombre], [Telefono], [Direccion], [DUI], [idCorreo]) VALUES (1, N'Luis Martínez', N'777-1111', N'Calle Principal 123', N'012345678', 2)
INSERT [dbo].[tblPaciente] ([idPaciente], [Nombre], [Telefono], [Direccion], [DUI], [idCorreo]) VALUES (2, N'María Gómez', N'777-2222', N'Avenida Secundaria 456', N'987654321', 3)
INSERT [dbo].[tblPaciente] ([idPaciente], [Nombre], [Telefono], [Direccion], [DUI], [idCorreo]) VALUES (3, N'Jorge Sánchez', N'777-3333', N'Boulevard Central 789', N'112233445', 1)
SET IDENTITY_INSERT [dbo].[tblPaciente] OFF
GO
SET IDENTITY_INSERT [dbo].[tblProcedimiento] ON 

INSERT [dbo].[tblProcedimiento] ([idProcedimiento], [Descripcion], [Costo], [Duracion]) VALUES (1, N'Limpieza Dental', 50, CAST(N'01:00:00' AS Time))
INSERT [dbo].[tblProcedimiento] ([idProcedimiento], [Descripcion], [Costo], [Duracion]) VALUES (2, N'Extracción de Muelas', 120, CAST(N'01:00:00' AS Time))
INSERT [dbo].[tblProcedimiento] ([idProcedimiento], [Descripcion], [Costo], [Duracion]) VALUES (3, N'Ortodoncia', 2000, CAST(N'02:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[tblProcedimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[tblTipoUsuario] ON 

INSERT [dbo].[tblTipoUsuario] ([idTipoUsuario], [Descripcion]) VALUES (1, N'Administrador')
INSERT [dbo].[tblTipoUsuario] ([idTipoUsuario], [Descripcion]) VALUES (2, N'Odontólogo')
INSERT [dbo].[tblTipoUsuario] ([idTipoUsuario], [Descripcion]) VALUES (3, N'Paciente')
SET IDENTITY_INSERT [dbo].[tblTipoUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUsuario] ON 

INSERT [dbo].[tblUsuario] ([idUsuario], [Usuario], [Contraseña], [idCorreo], [idTipoUsuario]) VALUES (1, N'admin1', N'admin123', 3, 1)
INSERT [dbo].[tblUsuario] ([idUsuario], [Usuario], [Contraseña], [idCorreo], [idTipoUsuario]) VALUES (2, N'odontologo1', N'odontopass', 1, 2)
INSERT [dbo].[tblUsuario] ([idUsuario], [Usuario], [Contraseña], [idCorreo], [idTipoUsuario]) VALUES (3, N'paciente1', N'pacientepass', 2, 3)
SET IDENTITY_INSERT [dbo].[tblUsuario] OFF
GO
ALTER TABLE [dbo].[tblCita]  WITH CHECK ADD FOREIGN KEY([idEstadoCita])
REFERENCES [dbo].[tblEstadoCita] ([idEstadoCita])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tblCita]  WITH CHECK ADD FOREIGN KEY([idOdontologo])
REFERENCES [dbo].[tblOdontologo] ([idOdontologo])
GO
ALTER TABLE [dbo].[tblCita]  WITH CHECK ADD FOREIGN KEY([idPaciente])
REFERENCES [dbo].[tblPaciente] ([idPaciente])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblCita]  WITH CHECK ADD FOREIGN KEY([idProcedimiento])
REFERENCES [dbo].[tblProcedimiento] ([idProcedimiento])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[tblOdontologo]  WITH CHECK ADD FOREIGN KEY([idCorreo])
REFERENCES [dbo].[tblCorreo] ([idCorreo])
GO
ALTER TABLE [dbo].[tblOdontologo]  WITH CHECK ADD FOREIGN KEY([idDisponible])
REFERENCES [dbo].[tblDisponibilidad] ([idDisponibilidad])
GO
ALTER TABLE [dbo].[tblPaciente]  WITH CHECK ADD  CONSTRAINT [FK__tblPacien__idCor__5070F446] FOREIGN KEY([idCorreo])
REFERENCES [dbo].[tblCorreo] ([idCorreo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblPaciente] CHECK CONSTRAINT [FK__tblPacien__idCor__5070F446]
GO
ALTER TABLE [dbo].[tblUsuario]  WITH CHECK ADD  CONSTRAINT [FK__tblUsuari__idCor__5535A963] FOREIGN KEY([idCorreo])
REFERENCES [dbo].[tblCorreo] ([idCorreo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblUsuario] CHECK CONSTRAINT [FK__tblUsuari__idCor__5535A963]
GO
ALTER TABLE [dbo].[tblUsuario]  WITH CHECK ADD  CONSTRAINT [FK__tblUsuari__idTip__5629CD9C] FOREIGN KEY([idTipoUsuario])
REFERENCES [dbo].[tblTipoUsuario] ([idTipoUsuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblUsuario] CHECK CONSTRAINT [FK__tblUsuari__idTip__5629CD9C]
GO
USE [master]
GO
ALTER DATABASE [db_clinica_dental] SET  READ_WRITE 
GO
