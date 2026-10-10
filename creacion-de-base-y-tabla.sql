
CREATE DATABASE [GastosDB];
GO

USE [GastosDB];
GO

CREATE TABLE [dbo].[Gastos] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Descripcion] NVARCHAR (100)  NOT NULL,
    [Monto]       DECIMAL (10, 2) NOT NULL,
    [Categoria]   NVARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

