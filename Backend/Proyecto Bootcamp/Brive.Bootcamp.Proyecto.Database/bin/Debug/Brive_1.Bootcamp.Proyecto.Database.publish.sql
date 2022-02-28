/*
Script de implementación para Bootcamp_Proyecto

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Bootcamp_Proyecto"
:setvar DefaultFilePrefix "Bootcamp_Proyecto"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creando Tabla [dbo].[BUSQUEDAS]...';


GO
CREATE TABLE [dbo].[BUSQUEDAS] (
    [ID_BUSQUEDA]        INT           IDENTITY (1, 1) NOT NULL,
    [EMPRESA_BUSCADA]    NVARCHAR (50) NOT NULL,
    [RESULTADO_BUSQUEDA] INT           NOT NULL,
    [FECHA_BUSQUEDA]     DATETIME      NOT NULL,
    CONSTRAINT [PK_BUSQUEDA] PRIMARY KEY CLUSTERED ([ID_BUSQUEDA] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[USUARIO_BUSQUEDA]...';


GO
CREATE TABLE [dbo].[USUARIO_BUSQUEDA] (
    [FK_USUARIO]  NVARCHAR (50) NOT NULL,
    [FK_BUSQUEDA] INT           NOT NULL
);


GO
PRINT N'Creando Tabla [dbo].[USUARIOS]...';


GO
CREATE TABLE [dbo].[USUARIOS] (
    [EMAIL]           NVARCHAR (50) NOT NULL,
    [NOMBRE]          NVARCHAR (50) NOT NULL,
    [A_PATERNO]       NVARCHAR (50) NOT NULL,
    [A_MATERNO]       NVARCHAR (50) NULL,
    [PASSWORD]        NCHAR (10)    NOT NULL,
    [FECHANACIMIENTO] DATETIME      NOT NULL,
    CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED ([EMAIL] ASC)
);


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[BUSQUEDAS]...';


GO
ALTER TABLE [dbo].[BUSQUEDAS]
    ADD DEFAULT (GETDATE()) FOR [FECHA_BUSQUEDA];


GO
PRINT N'Creando Clave externa [dbo].[FK_USUARIO]...';


GO
ALTER TABLE [dbo].[USUARIO_BUSQUEDA] WITH NOCHECK
    ADD CONSTRAINT [FK_USUARIO] FOREIGN KEY ([FK_USUARIO]) REFERENCES [dbo].[USUARIOS] ([EMAIL]);


GO
PRINT N'Creando Clave externa [dbo].[FK_BUSQUEDA]...';


GO
ALTER TABLE [dbo].[USUARIO_BUSQUEDA] WITH NOCHECK
    ADD CONSTRAINT [FK_BUSQUEDA] FOREIGN KEY ([FK_BUSQUEDA]) REFERENCES [dbo].[BUSQUEDAS] ([ID_BUSQUEDA]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[USUARIO_BUSQUEDA] WITH CHECK CHECK CONSTRAINT [FK_USUARIO];

ALTER TABLE [dbo].[USUARIO_BUSQUEDA] WITH CHECK CHECK CONSTRAINT [FK_BUSQUEDA];


GO
PRINT N'Actualización completada.';


GO
