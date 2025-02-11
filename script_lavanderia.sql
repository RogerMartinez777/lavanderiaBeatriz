USE [LavanderiaBeatriz]
GO
/****** Object:  Table [dbo].[Acolchados]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acolchados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[precio_unitario] [decimal](10, 2) NOT NULL,
	[id_tamanio] [int] NOT NULL,
 CONSTRAINT [PK_Acolchados] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[mail] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Entrega]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Entrega](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[interes] [int] NOT NULL,
	[id_acolchado] [int] NOT NULL,
 CONSTRAINT [PK_Detalles_Entrega] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Lavado]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Lavado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nro_lavado] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[id_acolchado] [int] NOT NULL,
 CONSTRAINT [PK_Detalles_Lavado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encargados_Recep]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encargados_Recep](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[alias] [varchar](50) NULL,
	[fecha_nacimiento] [date] NULL,
	[estado] [bit] NOT NULL,
	[id_Puesto] [int] NOT NULL,
 CONSTRAINT [PK_Encargados_Recep] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entregas]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entregas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[pagado] [bit] NOT NULL,
	[id_lavado] [int] NOT NULL,
	[id_detalle_entrega] [int] NOT NULL,
	[id_tipo_cobro] [int] NOT NULL,
 CONSTRAINT [PK_Entregas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lavados]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lavados](
	[nro_lavado] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[total] [decimal](10, 2) NOT NULL,
	[estado] [int] NOT NULL,
	[id_encargado_recep] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_tipo_cobro] [int] NOT NULL,
 CONSTRAINT [PK_Lavados] PRIMARY KEY CLUSTERED 
(
	[nro_lavado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tamanios]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tamanios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Cobro]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Cobro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipos_Pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Puesto]    Script Date: 05/12/2024 14:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Puesto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipos_Puesto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Encargados_Recep] ADD  CONSTRAINT [DF__Encargado__estad__32AB8735]  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Acolchados]  WITH CHECK ADD  CONSTRAINT [FK_Acolchados_Tamanio] FOREIGN KEY([id_tamanio])
REFERENCES [dbo].[Tamanios] ([id])
GO
ALTER TABLE [dbo].[Acolchados] CHECK CONSTRAINT [FK_Acolchados_Tamanio]
GO
ALTER TABLE [dbo].[Detalles_Entrega]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Entrega_Acolchados] FOREIGN KEY([id_acolchado])
REFERENCES [dbo].[Acolchados] ([id])
GO
ALTER TABLE [dbo].[Detalles_Entrega] CHECK CONSTRAINT [FK_Detalles_Entrega_Acolchados]
GO
ALTER TABLE [dbo].[Detalles_Lavado]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Lavado_Acolchados] FOREIGN KEY([id_acolchado])
REFERENCES [dbo].[Acolchados] ([id])
GO
ALTER TABLE [dbo].[Detalles_Lavado] CHECK CONSTRAINT [FK_Detalles_Lavado_Acolchados]
GO
ALTER TABLE [dbo].[Detalles_Lavado]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Lavado_Lavados] FOREIGN KEY([nro_lavado])
REFERENCES [dbo].[Lavados] ([nro_lavado])
GO
ALTER TABLE [dbo].[Detalles_Lavado] CHECK CONSTRAINT [FK_Detalles_Lavado_Lavados]
GO
ALTER TABLE [dbo].[Encargados_Recep]  WITH CHECK ADD  CONSTRAINT [FK_Encargados_Recep_Tipos_Puesto] FOREIGN KEY([id_Puesto])
REFERENCES [dbo].[Tipos_Puesto] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Encargados_Recep] CHECK CONSTRAINT [FK_Encargados_Recep_Tipos_Puesto]
GO
ALTER TABLE [dbo].[Entregas]  WITH CHECK ADD  CONSTRAINT [FK_Entregas_Detalles_Entrega] FOREIGN KEY([id_detalle_entrega])
REFERENCES [dbo].[Detalles_Entrega] ([id])
GO
ALTER TABLE [dbo].[Entregas] CHECK CONSTRAINT [FK_Entregas_Detalles_Entrega]
GO
ALTER TABLE [dbo].[Entregas]  WITH CHECK ADD  CONSTRAINT [FK_Entregas_Lavados] FOREIGN KEY([id_lavado])
REFERENCES [dbo].[Lavados] ([nro_lavado])
GO
ALTER TABLE [dbo].[Entregas] CHECK CONSTRAINT [FK_Entregas_Lavados]
GO
ALTER TABLE [dbo].[Lavados]  WITH CHECK ADD  CONSTRAINT [FK_Lavado_Tipos_Cobro] FOREIGN KEY([id_tipo_cobro])
REFERENCES [dbo].[Tipos_Cobro] ([id])
GO
ALTER TABLE [dbo].[Lavados] CHECK CONSTRAINT [FK_Lavado_Tipos_Cobro]
GO
ALTER TABLE [dbo].[Lavados]  WITH CHECK ADD  CONSTRAINT [FK_Lavados_Clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[Lavados] CHECK CONSTRAINT [FK_Lavados_Clientes]
GO
ALTER TABLE [dbo].[Lavados]  WITH CHECK ADD  CONSTRAINT [FK_Lavados_Encargados_Recep] FOREIGN KEY([id_encargado_recep])
REFERENCES [dbo].[Encargados_Recep] ([id])
GO
ALTER TABLE [dbo].[Lavados] CHECK CONSTRAINT [FK_Lavados_Encargados_Recep]
GO
