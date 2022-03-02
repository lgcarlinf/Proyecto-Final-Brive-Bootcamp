/*
Script de implementación para ProyectoFinal

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ProyectoFinal"
:setvar DefaultFilePrefix "ProyectoFinal"
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
/*
La tabla [dbo].[BUSQUEDAS] se va a quitar y a crear de nuevo porque se han redefinido todas las columnas no calculadas de la tabla.
*/

IF EXISTS (select top 1 1 from [dbo].[BUSQUEDAS])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
/*
El tipo de la columna PASSWORD en la tabla [dbo].[USUARIOS] es  VARCHAR (200) NOT NULL, pero se va a cambiar a  NCHAR (10) NOT NULL. Si la columna contiene datos no compatibles con el tipo  NCHAR (10) NOT NULL, podrían producirse pérdidas de datos y errores en la implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[USUARIOS])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
PRINT N'Quitando Restricción DEFAULT restricción sin nombre en [dbo].[BUSQUEDAS]...';


GO
ALTER TABLE [dbo].[BUSQUEDAS] DROP CONSTRAINT [DF__BUSQUEDAS__FECHA__276EDEB3];


GO
PRINT N'Quitando Clave externa [dbo].[FK_BUSQUEDA]...';


GO
ALTER TABLE [dbo].[USUARIO_BUSQUEDA] DROP CONSTRAINT [FK_BUSQUEDA];


GO
PRINT N'Quitando Tabla [dbo].[BUSQUEDAS]...';


GO
DROP TABLE [dbo].[BUSQUEDAS];


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
PRINT N'Modificando Tabla [dbo].[USUARIOS]...';


GO
ALTER TABLE [dbo].[USUARIOS] ALTER COLUMN [PASSWORD] NCHAR (10) NOT NULL;


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[BUSQUEDAS]...';


GO
ALTER TABLE [dbo].[BUSQUEDAS]
    ADD DEFAULT (GETDATE()) FOR [FECHA_BUSQUEDA];


GO
PRINT N'Actualización completada.';


GO
