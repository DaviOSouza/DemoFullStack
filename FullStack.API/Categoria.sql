USE [DemoDB]
GO

/****** Objeto: Table [dbo].[Categoria] Data do Script: 13/12/2024 17:09:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categoria] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome] NVARCHAR (50) NOT NULL
);


