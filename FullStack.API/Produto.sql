USE [DemoDB]
GO

/****** Objeto: Table [dbo].[Produto] Data do Script: 13/12/2024 17:12:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produto] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Nome]            NVARCHAR (50)  NOT NULL,
    [Descricao]       NVARCHAR (100) NULL,
    [Preco]           DECIMAL (18)   NOT NULL,
    [Quantidade]      INT            NOT NULL,
    [CodigoCategoria] INT            NOT NULL
);


