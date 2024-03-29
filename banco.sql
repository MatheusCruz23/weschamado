USE [FastTicket]
GO
/****** Object:  Table [dbo].[Acompanhamento]    Script Date: 31/07/2019 13:09:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acompanhamento](
	[IDAcompanhamento] [int] IDENTITY(1,1) NOT NULL,
	[Acompanhamento] [varchar](500) NULL,
	[HoraAcompanhamento] [datetime] NULL,
	[FKIDChamado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDAcompanhamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agente]    Script Date: 31/07/2019 13:09:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agente](
	[IDAgente] [int] IDENTITY(1,1) NOT NULL,
	[NomeAgente] [varchar](45) NOT NULL,
	[Funcao] [varchar](45) NOT NULL,
	[Usuario] [varchar](45) NOT NULL,
	[Senha] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDAgente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chamado]    Script Date: 31/07/2019 13:09:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chamado](
	[IDChamado] [int] IDENTITY(1,1) NOT NULL,
	[DataAbertura] [datetime] NOT NULL,
	[Assunto] [varchar](45) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[FKCliente] [int] NOT NULL,
	[FKNomeAgente] [int] NOT NULL,
	[FKStatusChamado] [int] NOT NULL,
	[FKProduto] [int] NOT NULL,
	[FKAcompanhamento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDChamado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 31/07/2019 13:09:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IDCliente] [int] IDENTITY(1,1) NOT NULL,
	[Cnpj] [varchar](45) NOT NULL,
	[Cliente] [varchar](50) NOT NULL,
	[FKTipoContrato] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contato]    Script Date: 31/07/2019 13:09:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contato](
	[IDContato] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Telefone] [varchar](32) NULL,
	[Email] [varchar](60) NULL,
	[FKCliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDContato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 31/07/2019 13:09:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrato](
	[IDContrato] [int] IDENTITY(1,1) NOT NULL,
	[TipoContrato] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDContrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 31/07/2019 13:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[IDProduto] [int] IDENTITY(1,1) NOT NULL,
	[Produto] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 31/07/2019 13:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[IDStatus] [int] IDENTITY(1,1) NOT NULL,
	[StatusChamado] [varchar](40) NOT NULL,
	[HoraStatus] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Chamado]  WITH CHECK ADD  CONSTRAINT [FKChamadoAcompanhamento] FOREIGN KEY([FKAcompanhamento])
REFERENCES [dbo].[Acompanhamento] ([IDAcompanhamento])
GO
ALTER TABLE [dbo].[Chamado] CHECK CONSTRAINT [FKChamadoAcompanhamento]
GO
ALTER TABLE [dbo].[Chamado]  WITH CHECK ADD  CONSTRAINT [FKChamadoAgente] FOREIGN KEY([FKNomeAgente])
REFERENCES [dbo].[Agente] ([IDAgente])
GO
ALTER TABLE [dbo].[Chamado] CHECK CONSTRAINT [FKChamadoAgente]
GO
ALTER TABLE [dbo].[Chamado]  WITH CHECK ADD  CONSTRAINT [FKChamadoCliente] FOREIGN KEY([FKCliente])
REFERENCES [dbo].[Cliente] ([IDCliente])
GO
ALTER TABLE [dbo].[Chamado] CHECK CONSTRAINT [FKChamadoCliente]
GO
ALTER TABLE [dbo].[Chamado]  WITH CHECK ADD  CONSTRAINT [FKChamadoProduto] FOREIGN KEY([FKProduto])
REFERENCES [dbo].[Produto] ([IDProduto])
GO
ALTER TABLE [dbo].[Chamado] CHECK CONSTRAINT [FKChamadoProduto]
GO
ALTER TABLE [dbo].[Chamado]  WITH CHECK ADD  CONSTRAINT [FKChamadoStatus] FOREIGN KEY([FKStatusChamado])
REFERENCES [dbo].[Status] ([IDStatus])
GO
ALTER TABLE [dbo].[Chamado] CHECK CONSTRAINT [FKChamadoStatus]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FKClienteContrato] FOREIGN KEY([FKTipoContrato])
REFERENCES [dbo].[Contrato] ([IDContrato])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FKClienteContrato]
GO
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FKContatoCliente] FOREIGN KEY([FKCliente])
REFERENCES [dbo].[Cliente] ([IDCliente])
GO
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FKContatoCliente]
GO
