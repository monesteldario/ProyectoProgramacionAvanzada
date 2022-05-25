USE [master]
GO
/****** Object:  Database [Worknet]    Script Date: 25/4/2022 22:30:42 ******/
CREATE DATABASE [Worknet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Worknet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Worknet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Worknet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Worknet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Worknet] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Worknet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Worknet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Worknet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Worknet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Worknet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Worknet] SET ARITHABORT OFF 
GO
ALTER DATABASE [Worknet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Worknet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Worknet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Worknet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Worknet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Worknet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Worknet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Worknet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Worknet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Worknet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Worknet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Worknet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Worknet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Worknet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Worknet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Worknet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Worknet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Worknet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Worknet] SET  MULTI_USER 
GO
ALTER DATABASE [Worknet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Worknet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Worknet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Worknet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Worknet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Worknet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Worknet] SET QUERY_STORE = OFF
GO
USE [Worknet]
GO
/****** Object:  Table [dbo].[BITACORA]    Script Date: 25/4/2022 22:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BITACORA](
	[FECHA_HORA] [datetime] NOT NULL,
	[DESCRIPCION_ERROR] [varchar](2500) NOT NULL,
	[CODIGO_ERROR] [bigint] NOT NULL,
	[ORIGEN] [varchar](100) NOT NULL,
	[CONSECUTIVO] [bigint] IDENTITY(1,1) NOT NULL,
	[CORREO_USUARIO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BITACORA] PRIMARY KEY CLUSTERED 
(
	[CONSECUTIVO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CANDIDATOS]    Script Date: 25/4/2022 22:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CANDIDATOS](
	[NOMBRE_CANDIDATO] [varchar](20) NOT NULL,
	[APELLIDO_CANDIDATO] [varchar](90) NOT NULL,
	[EXP_CANDIDATO] [int] NOT NULL,
	[GRADO_ESTUDIO] [varchar](100) NOT NULL,
	[TELEFONO_CANDIDATO] [int] NOT NULL,
	[AREA_INTERES] [bigint] NOT NULL,
	[CORREO_USUARIO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CANDIDATOS] PRIMARY KEY CLUSTERED 
(
	[CORREO_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 25/4/2022 22:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[ID_CATEGORIA] [bigint] IDENTITY(1,1) NOT NULL,
	[CATEGORIA_DESCRIPCION] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEOS]    Script Date: 25/4/2022 22:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEOS](
	[ID_EMPLEO] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_CATEGORIA] [bigint] NOT NULL,
	[EXP_MINIMA] [int] NOT NULL,
	[GRADO_ESTUDIO] [varchar](50) NOT NULL,
	[COMPANIA] [varchar](50) NOT NULL,
	[EMPLEO_NOMBRE] [varchar](100) NOT NULL,
	[ESTADO_PUESTO] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](2000) NOT NULL,
	[REQUISITOS] [varchar](2000) NOT NULL,
	[CORREO_RECLUTADOR] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RECLUTADORES]    Script Date: 25/4/2022 22:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RECLUTADORES](
	[CORREO_RECLUTADOR] [varchar](50) NOT NULL,
	[NOMBRE_RECLUTADOR] [varchar](50) NOT NULL,
	[APELLIDO_RECLUTADOR] [varchar](50) NOT NULL,
	[COMPANIA] [varchar](50) NOT NULL,
	[TELEFONO_RECLUTADOR] [int] NOT NULL,
 CONSTRAINT [PK_RECLUTADORESS] PRIMARY KEY CLUSTERED 
(
	[CORREO_RECLUTADOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 25/4/2022 22:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[ID_ROL] [bigint] IDENTITY(1,1) NOT NULL,
	[NOMBRE_ROL] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOLICITUDES]    Script Date: 25/4/2022 22:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOLICITUDES](
	[ID_SOLICITUD] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_EMPLEO] [bigint] NOT NULL,
	[CORREO_CANDIDATO] [varchar](50) NOT NULL,
	[FECHA_SOLICITUD] [datetime] NOT NULL,
 CONSTRAINT [XPKSOLICITUDES] PRIMARY KEY CLUSTERED 
(
	[ID_SOLICITUD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 25/4/2022 22:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[CORREO_USUARIO] [varchar](50) NOT NULL,
	[CONTRASENA] [varchar](50) NOT NULL,
	[ID_ROL] [bigint] NOT NULL,
 CONSTRAINT [XPKUSUARIOS] PRIMARY KEY CLUSTERED 
(
	[CORREO_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BITACORA] ON 

INSERT [dbo].[BITACORA] ([FECHA_HORA], [DESCRIPCION_ERROR], [CODIGO_ERROR], [ORIGEN], [CONSECUTIVO], [CORREO_USUARIO]) VALUES (CAST(N'2022-04-25T16:42:30.957' AS DateTime), N'error de prueba', 999, N'BD Worknet', 1, N'reclutador@gmail.com')
SET IDENTITY_INSERT [dbo].[BITACORA] OFF
GO
INSERT [dbo].[CANDIDATOS] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Erick ', N'Guillen ', 1, N'Estudiante Universitario', 97843243, 4, N'eguillen80064@ufide.ac.cr')
INSERT [dbo].[CANDIDATOS] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Fernando', N'Morales', 6, N'Licenciado', 86834542, 1, N'fmc.cr@hotmail.com')
INSERT [dbo].[CANDIDATOS] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Dario', N'Monestel', 3, N'Bachiller Universitario', 67768234, 1, N'gmonestel90215@ufide.ac.cr')
INSERT [dbo].[CANDIDATOS] ([NOMBRE_CANDIDATO], [APELLIDO_CANDIDATO], [EXP_CANDIDATO], [GRADO_ESTUDIO], [TELEFONO_CANDIDATO], [AREA_INTERES], [CORREO_USUARIO]) VALUES (N'Reiner', N'Navarro', 4, N'Estudiante Universitario', 56364532, 4, N'rnavarro40928@ufide.ac.cr')
GO
SET IDENTITY_INSERT [dbo].[CATEGORIAS] ON 

INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (1, N'Informatica')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (2, N'Administracion')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (3, N'Servicio al Cliente')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (4, N'Cocina')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (5, N'Salud')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (6, N'Ingenieria e Industria')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (7, N'Economia y Finanzas')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (8, N'Educacion')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (9, N'Turismo')
INSERT [dbo].[CATEGORIAS] ([ID_CATEGORIA], [CATEGORIA_DESCRIPCION]) VALUES (10, N'Otros')
SET IDENTITY_INSERT [dbo].[CATEGORIAS] OFF
GO
SET IDENTITY_INSERT [dbo].[EMPLEOS] ON 

INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (3, 4, 0, N'Noveno Año', N'McDonalds', N'Cocinero', N'Activo', N'Se requiere una persona con disponibildad de horarios. No experiencia previa es necesaria pero es preferible que tenga experiencia en puestos similares', N'Curso Manejo de Alimentos requerido', N'agchaverri@manpower.com.mx')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (15, 2, 6, N'Lienciado', N'Bac San Jose', N'Gerente de Sucursal Bancaria', N'Activo', N'Se requiere Gerente para surcursal fuera del GAM.  Las personas interesadas deberan tener experiancia previa en el mismo puesto y  tener la capacidad de trasladarse  fuera del GAM en caso de ser seleccionado/a', N'Graduado en Economia, Finanzas o Administracion de Empresas. Tener amplia experiencia manejando equipos de trabajado y  haber trabajado en puestos similares', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (17, 3, 0, N'Bachiller Colegial', N'Amazon', N'Agente de servicio al cliente', N'Activo', N'Agente de servicio al cliente para Amazon. Se requeire que la persona pueda garantizar un buena comunicacion oral y escrita para establecer relacion con los clientes y mantener un buen trabajo en equipo. No se necestita experiencia previa.  El puesto ofrece flexibilidad de horarios y posiblidad de trabajar desde la casa (WFH)', N'Manejo del Idioma Ingles. Conocimientos en Excel y conocimientos tecnicos basicos son preferibles.', N'marco.lopez@delaUalBrete.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (21, 5, 2, N'Bachiller Colegial', N'Hospital Clinica Biblica', N'Asistente de Terapia Fisica', N'Activo', N'Puesto disponible para estudiante universitario o graduado de terapia fisica para asistir a un grupo de terapia con enfoque en movilidad para adultos mayores.', N'Al menos un 60% de la carrera universitaria de Terapia Fisica completa. Experiencia trbajando con adultos mayoes es deseable', N'mrodriguez@do.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (26, 1, 4, N'Licenciado', N'CompuTrabajo', N'Senior Developer', N'Activo', N'Java', N'Ingles', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (27, 1, 3, N'Bachiller Colegial', N'CompuTrabajo', N'Técnico en Soporte', N'Activo', N'Se necesita Técnico en Soporte, con amplia disponibilidad de horario.
Residente preferiblemente de la zona del GAM.', N'Técnico en Soporte, conocimiento relacionado al cargo, experiencia en puestos similares.', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (28, 1, 2, N'Bachiller Universitario', N'CompuTrabajo', N'Frontend Developer', N'Activo', N'Se busca diseñador, con amplio conocimiento en el área', N'Bachillerato en Ingeniería en Sistemas, experiencia en puestos similares', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (29, 1, 1, N'Bachiller Universitario', N'CompuTrabajo', N' Junior Backend Developer (Java)', N'Activo', N'Buscamos programador con conocimiento en Java, con actitud positiva, facilidad para trabajar en conjunto', N'Bachillerato en Ingeniería en Sistemas o Ingeniería en Computación ', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (30, 1, 3, N'Técnico Medio', N'CompuTrabajo', N'Analista de Datos', N'Activo', N'Buscamos analista de Datos con conocimiento amplio en Base de Datos y con experiencia en SQL Server, experiencia en Power BI.', N'Técnico en Analista de Datos o preferiblemente bachillerato en ingeniería en sistemas de Computación ', N'reclutador@gmail.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (31, 5, 4, N'Licenciado', N'BuscoJobs', N'Medico Cirujano ', N'Activo', N'Se solicita medico cirujano estético para clínica privada ubicada en San Rafael de Heredia.', N'Licenciatura en medicina general con énfasis en cirugía estética  ', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (32, 1, 15, N'Licenciado', N'BuscoJobs', N'Marketing Manager', N'Activo', N'Se busca gerente en mercadeo, especializado en supermercados. Con amplia experiencia en el cargo.
Para trabajar de inmediato en supermercado ubicado en Cartago centro', N'Licenciado en Marketing y Ventas.
Disponibilidad inmediata.
Experiencia en puestos similares
', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (33, 3, 3, N'Técnico Medio', N'BuscoJobs', N'Agente de Ventas', N'Activo', N'Encargado/a de formalizar contratos y brindar información al cliente con respecto a los términos y condiciones del alquiler de los vehículos, ventas de coberturas y productos adicionales.

Atender a los clientes en counter, vía telefónica y/o mensajería para reservaciones, cotizaciones de tarifas, preguntas generales, asistencias; y brinde información y resolución para clientes, otras sucursales y otros proveedores.

Ofrecer asistencia adicional al cliente sobre direcciones, mapas, información del área local e información del servicio adecuada, brindando excelencia en la atención al cliente.', N'Licencia B1
Ingles Intermedio
Buena presentación
Excelente comunicación


', N'jose.sanchez@buscojobs.cr')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (34, 1, 2, N'Noveno Año', N'TUASA', N'Mecánico de Auto Bus', N'Activo', N'Se busca mecánico para trabajar en plantel Lumaca.', N'Licencia B2 y C2 indispensable.
Experiencia comprobable.
Disponibilidad de horario.
', N'wedwed@correo.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (35, 1, 3, N'Noveno Año', N'Lumaca', N'Mecánico General', N'Activo', N'Necesitamos mecánico general con experiencia amplia y comprobable, para laborar en Alajuela', N'Licencia B1 o B2 indispensable.
Responsable y honesto.
Disponibilidad inmediata', N'wedwed@correo.com')
INSERT [dbo].[EMPLEOS] ([ID_EMPLEO], [ID_CATEGORIA], [EXP_MINIMA], [GRADO_ESTUDIO], [COMPANIA], [EMPLEO_NOMBRE], [ESTADO_PUESTO], [DESCRIPCION], [REQUISITOS], [CORREO_RECLUTADOR]) VALUES (36, 1, 1, N'Noveno Año', N'El Balcón del Marisco', N'Mesero', N'Activo', N'Se busca mesero, con facilidad de trasladarse dentro del GAM', N'Curso de manipulación de alimentos.
Disponibilidad de horario.
Respetuoso y responsable.', N'wedwed@correo.com')
SET IDENTITY_INSERT [dbo].[EMPLEOS] OFF
GO
INSERT [dbo].[RECLUTADORES] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'agchaverri@manpower.com.mx', N'Ana', N'Chaverri Rojas', N'Manpower', 434325325)
INSERT [dbo].[RECLUTADORES] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'jose.sanchez@buscojobs.cr', N'Jose', N'Sanchez Brenes', N'BuscoJobs', 352352352)
INSERT [dbo].[RECLUTADORES] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'marco.lopez@delaUalBrete.com', N'Marco', N'Lopez Zuniga', N'DelaUalBrete', 343242342)
INSERT [dbo].[RECLUTADORES] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'mrodriguez@do.com', N'Maria ', N'Rodriguez Chaves', N'TrabajoCR', 694876743)
INSERT [dbo].[RECLUTADORES] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'reclutador@gmail.com', N'Javier', N'Mendez Castillo', N'CompuTrabajo', 642432434)
INSERT [dbo].[RECLUTADORES] ([CORREO_RECLUTADOR], [NOMBRE_RECLUTADOR], [APELLIDO_RECLUTADOR], [COMPANIA], [TELEFONO_RECLUTADOR]) VALUES (N'wedwed@correo.com', N'Candidato', N'Prueva', N'Microsodr', 43242342)
GO
SET IDENTITY_INSERT [dbo].[ROLES] ON 

INSERT [dbo].[ROLES] ([ID_ROL], [NOMBRE_ROL]) VALUES (1, N'Reclutador')
INSERT [dbo].[ROLES] ([ID_ROL], [NOMBRE_ROL]) VALUES (2, N'Candidato')
SET IDENTITY_INSERT [dbo].[ROLES] OFF
GO
SET IDENTITY_INSERT [dbo].[SOLICITUDES] ON 

INSERT [dbo].[SOLICITUDES] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (6, 17, N'eguillen80064@ufide.ac.cr', CAST(N'2022-04-17T00:00:00.000' AS DateTime))
INSERT [dbo].[SOLICITUDES] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (9, 21, N'rnavarro40928@ufide.ac.cr', CAST(N'2022-03-15T00:00:00.000' AS DateTime))
INSERT [dbo].[SOLICITUDES] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (11, 17, N'fmc.cr@hotmail.com', CAST(N'2022-04-22T22:01:42.467' AS DateTime))
INSERT [dbo].[SOLICITUDES] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (12, 3, N'fmc.cr@hotmail.com', CAST(N'2022-04-22T22:02:25.407' AS DateTime))
INSERT [dbo].[SOLICITUDES] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (13, 21, N'fmc.cr@hotmail.com', CAST(N'2022-04-24T22:59:31.900' AS DateTime))
INSERT [dbo].[SOLICITUDES] ([ID_SOLICITUD], [ID_EMPLEO], [CORREO_CANDIDATO], [FECHA_SOLICITUD]) VALUES (14, 26, N'fmc.cr@hotmail.com', CAST(N'2022-04-24T23:46:31.803' AS DateTime))
SET IDENTITY_INSERT [dbo].[SOLICITUDES] OFF
GO
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'agchaverri@manpower.com.mx', N'r2r2r2r23r34', 1)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'eguillen80064@ufide.ac.cr', N'1234', 2)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'fmc.cr@gmail.com', N'4321', 1)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'fmc.cr@hotmail.com', N'1234', 2)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'gmonestel90215@ufide.ac.cr', N'1234', 2)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'jose.sanchez@buscojobs.cr', N'vwvODanodx', 1)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'marco.lopez@delaUalBrete.com', N'cweHGXOSvwev', 1)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'mrodriguez@do.com', N'ixqoxnw23123', 1)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'reclutador@gmail.com', N'1234', 1)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'rnavarro40928@ufide.ac.cr', N'1234', 2)
INSERT [dbo].[USUARIOS] ([CORREO_USUARIO], [CONTRASENA], [ID_ROL]) VALUES (N'wedwed@correo.com', N'1234', 1)
GO
/****** Object:  Index [XPKCATEGORIAS]    Script Date: 25/4/2022 22:30:43 ******/
ALTER TABLE [dbo].[CATEGORIAS] ADD  CONSTRAINT [XPKCATEGORIAS] PRIMARY KEY NONCLUSTERED 
(
	[ID_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [XPKEMPLEOS]    Script Date: 25/4/2022 22:30:43 ******/
ALTER TABLE [dbo].[EMPLEOS] ADD  CONSTRAINT [XPKEMPLEOS] PRIMARY KEY NONCLUSTERED 
(
	[ID_EMPLEO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [XPKROLES]    Script Date: 25/4/2022 22:30:43 ******/
ALTER TABLE [dbo].[ROLES] ADD  CONSTRAINT [XPKROLES] PRIMARY KEY NONCLUSTERED 
(
	[ID_ROL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BITACORA]  WITH CHECK ADD  CONSTRAINT [FK_BITACORA_USUARIOS] FOREIGN KEY([CORREO_USUARIO])
REFERENCES [dbo].[USUARIOS] ([CORREO_USUARIO])
GO
ALTER TABLE [dbo].[BITACORA] CHECK CONSTRAINT [FK_BITACORA_USUARIOS]
GO
ALTER TABLE [dbo].[CANDIDATOS]  WITH CHECK ADD  CONSTRAINT [FK_CANDIDATOS_CATEGORIAS] FOREIGN KEY([AREA_INTERES])
REFERENCES [dbo].[CATEGORIAS] ([ID_CATEGORIA])
GO
ALTER TABLE [dbo].[CANDIDATOS] CHECK CONSTRAINT [FK_CANDIDATOS_CATEGORIAS]
GO
ALTER TABLE [dbo].[CANDIDATOS]  WITH CHECK ADD  CONSTRAINT [R_8] FOREIGN KEY([CORREO_USUARIO])
REFERENCES [dbo].[USUARIOS] ([CORREO_USUARIO])
GO
ALTER TABLE [dbo].[CANDIDATOS] CHECK CONSTRAINT [R_8]
GO
ALTER TABLE [dbo].[EMPLEOS]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEOS_CATEGORIAS] FOREIGN KEY([ID_CATEGORIA])
REFERENCES [dbo].[CATEGORIAS] ([ID_CATEGORIA])
GO
ALTER TABLE [dbo].[EMPLEOS] CHECK CONSTRAINT [FK_EMPLEOS_CATEGORIAS]
GO
ALTER TABLE [dbo].[EMPLEOS]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEOS_RECLUTADORES] FOREIGN KEY([CORREO_RECLUTADOR])
REFERENCES [dbo].[RECLUTADORES] ([CORREO_RECLUTADOR])
GO
ALTER TABLE [dbo].[EMPLEOS] CHECK CONSTRAINT [FK_EMPLEOS_RECLUTADORES]
GO
ALTER TABLE [dbo].[RECLUTADORES]  WITH CHECK ADD  CONSTRAINT [FK_RECLUTADORES_USUARIOS] FOREIGN KEY([CORREO_RECLUTADOR])
REFERENCES [dbo].[USUARIOS] ([CORREO_USUARIO])
GO
ALTER TABLE [dbo].[RECLUTADORES] CHECK CONSTRAINT [FK_RECLUTADORES_USUARIOS]
GO
ALTER TABLE [dbo].[SOLICITUDES]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUDES_CANDIDATOS] FOREIGN KEY([CORREO_CANDIDATO])
REFERENCES [dbo].[CANDIDATOS] ([CORREO_USUARIO])
GO
ALTER TABLE [dbo].[SOLICITUDES] CHECK CONSTRAINT [FK_SOLICITUDES_CANDIDATOS]
GO
ALTER TABLE [dbo].[SOLICITUDES]  WITH CHECK ADD  CONSTRAINT [R_6] FOREIGN KEY([ID_EMPLEO])
REFERENCES [dbo].[EMPLEOS] ([ID_EMPLEO])
GO
ALTER TABLE [dbo].[SOLICITUDES] CHECK CONSTRAINT [R_6]
GO
ALTER TABLE [dbo].[USUARIOS]  WITH CHECK ADD  CONSTRAINT [R_4] FOREIGN KEY([ID_ROL])
REFERENCES [dbo].[ROLES] ([ID_ROL])
GO
ALTER TABLE [dbo].[USUARIOS] CHECK CONSTRAINT [R_4]
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Candidato]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Candidato] @pNombre VARCHAR(50),@pApellido VARCHAR(50),
@pExp INT, @pGradoEstudio VARCHAR(50),@pTelefono INT, @pAreaInteres INT, @pCorreo VARCHAR(50)  
AS
UPDATE CANDIDATOS  
SET [NOMBRE_CANDIDATO] = @pNombre, [APELLIDO_CANDIDATO] = @pApellido, 
[EXP_CANDIDATO] = @pExp,[GRADO_ESTUDIO] = @pGradoEstudio, [TELEFONO_CANDIDATO] = @pTelefono, [AREA_INTERES] = @pAreaInteres
WHERE [CORREO_USUARIO] = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Empleo]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Empleo]
@pEmpleo VARCHAR(100), @pCompania VARCHAR(100), @pRequisitos VARCHAR(500), 
@pDescripcion VARCHAR(500), @pExperiencia INT, @pEstudios VARCHAR(500), @pEstado VARCHAR(200), 
@pCategoria INT, @pIdPuesto INT
AS
UPDATE EMPLEOS
SET [EMPLEO_NOMBRE] = @pEmpleo,
[COMPANIA] = @pCompania, [REQUISITOS] = @pRequisitos, 
[DESCRIPCION] = @pDescripcion, [EXP_MINIMA] = @pExperiencia, 
[GRADO_ESTUDIO] = @pEstudios, [ESTADO_PUESTO] = @pEstado, [ID_CATEGORIA] = @pCategoria
WHERE [ID_EMPLEO] = @pIdPuesto;
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Reclutador]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Actualizar_Reclutador] 
@pNombre VARCHAR(100), @pApellido VARCHAR(100), @pCompania VARCHAR(100), 
@pTelefono INT, @pCorreo VARCHAR(150)
AS
UPDATE RECLUTADORES
SET [NOMBRE_RECLUTADOR] = @pNombre, [APELLIDO_RECLUTADOR] = @pApellido, 
[COMPANIA] = @pCompania,[TELEFONO_RECLUTADOR]= @pTelefono
WHERE [CORREO_RECLUTADOR] = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Buscar_Usuario]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Buscar_Usuario] @pCorreo VARCHAR(50), @pContrasena VARCHAR(50)
AS
SELECT * FROM [dbo].[USUARIOS] U
WHERE u.[CORREO_USUARIO] = @pCorreo AND u.[CONTRASENA] = @pContrasena;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Candidato]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Candidato] @pCorreo VARCHAR(150)
AS
SELECT C.*, CT.categoria_descripcion FROM [dbo].[CANDIDATOS] C
INNER JOIN [dbo].[CATEGORIAS] CT on C.area_interes = CT.id_categoria
WHERE C.correo_usuario = @pCorreo  
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Categorias]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Categorias]
AS
SELECT C.id_Categoria, C.categoria_descripcion
FROM categorias C;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Empleo]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Empleo] @pIdEmpleo bigint
AS
SELECT E.*, C.categoria_descripcion FROM empleos E
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.id_empleo = @pIdEmpleo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Empleo_Aplicado]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Empleo_Aplicado]

@pCorreo AS VARCHAR(50),
@pIdEmpleo AS BIGINT
AS

BEGIN

Select * from SOLICITUDES S
where S.ID_EMPLEO = @pIdEmpleo AND S.CORREO_CANDIDATO = @pCorreo; 

END

GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Reclutador]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Reclutador] @pCorreo VARCHAR(150)
AS
SELECT * from [dbo].[RECLUTADORES] R 
Where R.correo_reclutador = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Solicitudes]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Consultar_Solicitudes]
@pCorreo AS VARCHAR(50)
AS
BEGIN

SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUDES s
left JOIN empleos E on S.id_empleo  = E.id_empleo)
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.correo_reclutador = @pCorreo or S.CORREO_CANDIDATO = @pCorreo;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_Solicitudes_por_id]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create     PROCEDURE [dbo].[SP_Consultar_Solicitudes_por_id] @pid bigint
AS
SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUDES s
left JOIN empleos E on S.id_empleo  = E.id_empleo)
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE S.ID_SOLICITUD = @pid;

 
GO
/****** Object:  StoredProcedure [dbo].[SP_Empleo_Inteligente]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Empleo_Inteligente] @pAreaInteres INT, @pExp INT, 
@pGradoEstudio VARCHAR(50) AS
SELECT E.*, C.CATEGORIA_DESCRIPCION FROM empleos E
Inner join CATEGORIAS C on E.id_categoria = C.id_categoria
WHERE E.estado_puesto='Activo' 
AND E.id_Categoria= @pAreaInteres AND E.EXP_MINIMA<=@pExp AND E.grado_estudio=@pGradoEstudio;
GO
/****** Object:  StoredProcedure [dbo].[SP_Empleos_Publicados]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Empleos_Publicados] @pCorreo VARCHAR(150)
AS
SELECT E.*, C.categoria_descripcion FROM empleos E
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.CORREO_RECLUTADOR = @pCorreo;
GO
/****** Object:  StoredProcedure [dbo].[SP_Filtrar_Categorias]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Filtrar_Categorias] @pCategoria INT
AS
SELECT E.*, C.categoria_descripcion FROM empleos E
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.id_Categoria= @pCategoria AND E.estado_puesto = 'Activo';
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Bitacora]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Bitacora] 

@pDescripcion varchar(2500),
@pOrigen varchar(100),
@pCorreo_Usuario varchar(50)
AS
BEGIN

	INSERT INTO BITACORA([FECHA_HORA],[DESCRIPCION_ERROR],[CODIGO_ERROR],[ORIGEN],[CORREO_USUARIO]) 
	VALUES(GETDATE(),@pDescripcion,'999',@pOrigen,@pCorreo_Usuario);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Candidato]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Candidato] @pCorreo VARCHAR(150), 
@pNombre VARCHAR(100), @pApellido VARCHAR(100), @pExp INT, @pGradoEstudio VARCHAR(20), @pTelefono INT, @pAreaInteres INT
AS
INSERT INTO[CANDIDATOS]([NOMBRE_CANDIDATO],[APELLIDO_CANDIDATO],[EXP_CANDIDATO],[GRADO_ESTUDIO],[TELEFONO_CANDIDATO],[AREA_INTERES],[CORREO_USUARIO]) 
VALUES(@pNombre,@pApellido,@pExp,@pGradoEstudio,@pTelefono,@pAreaInteres,@pCorreo);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Empleo]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Empleo] @pNombreEmpleo VARCHAR(100), @pRequisitos VARCHAR(1000), 
@pDescripcionGeneral VARCHAR(1000), @pCompania VARCHAR(30), @pIdCategoria INT, 
@pCorreo VARCHAR(150), @pEstado VARCHAR(20), @pExperienciaMinima INT, @pGradoEstudio VARCHAR(50)
AS
INSERT INTO empleos(empleo_nombre,requisitos,descripcion,
compania,id_Categoria,CORREO_RECLUTADOR,estado_puesto,EXP_MINIMA,grado_estudio) 
VALUES(@pNombreEmpleo,@pRequisitos,@pDescripcionGeneral,
@pCompania,@pIdCategoria,@pCorreo,@pEstado,@pExperienciaMinima,@pGradoEstudio); 
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Reclutador]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_Insertar_Reclutador] @pCorreo VARCHAR(150), @pNombre VARCHAR(100),
@pApellido VARCHAR(100), @pCompania VARCHAR(50), @pTelefono INT
AS
INSERT INTO RECLUTADORES(NOMBRE_RECLUTADOR,APELLIDO_RECLUTADOR,COMPANIA,TELEFONO_RECLUTADOR,correo_reclutador) 
VALUES(@pNombre,@pApellido,@pCompania,@pTelefono,@pCorreo);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Solicitudes]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Insertar_Solicitudes] @pCorreoCandidato VARCHAR(100), @pIdEmpleo INT
AS
INSERT INTO SOLICITUDES(correo_candidato, id_empleo, fecha_solicitud)
VALUES(@pCorreoCandidato,@pIdEmpleo, CURRENT_TIMESTAMP);
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Usuario]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Insertar_Usuario] @pCorreo VARCHAR(150), @pPassword VARCHAR(100), @pIdRol INT
AS
INSERT INTO USUARIOS([CORREO_USUARIO],[CONTRASENA],id_rol) VALUES(@pCorreo,@pPassword,@pIdRol);
GO
/****** Object:  StoredProcedure [dbo].[SP_Llenar_Candidatos]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Llenar_Candidatos] 
AS
SELECT C.*, CT.categoria_descripcion FROM [dbo].[CANDIDATOS] C
INNER JOIN categorias CT on C.area_interes = CT.id_categoria;
GO
/****** Object:  StoredProcedure [dbo].[SP_Llenar_Empleos]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_Llenar_Empleos]
AS
SELECT E.*, C.categoria_descripcion FROM EMPLEOS E
INNER JOIN categorias C on E.id_categoria = C.id_categoria
WHERE E.estado_puesto = 'Activo';
GO
/****** Object:  StoredProcedure [dbo].[SP_Ver_Solicitudes]    Script Date: 25/4/2022 22:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROCEDURE [dbo].[SP_Ver_Solicitudes] 
AS
SELECT E.*, C.categoria_descripcion, S.ID_SOLICITUD, S.FECHA_SOLICITUD, S.CORREO_CANDIDATO FROM (SOLICITUDES s
left JOIN empleos E on S.id_empleo  = E.id_empleo)
INNER JOIN categorias C on E.id_categoria = C.id_categoria
GO
USE [master]
GO
ALTER DATABASE [Worknet] SET  READ_WRITE 
GO
