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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 9f7d4e73-04fc-40a7-9a3a-f5e1d0f08ac0, 4847e470-02ab-4030-97dd-e64606a17796, 69d951c6-69fa-46f2-b091-8f897ed9bdc6, 5265df91-fb96-4cde-bae0-1ff44ef74cae se ha omitido; no se cambiará el nombre del elemento [dbo].[USUARIOS].[Id] (SqlSimpleColumn) a EMAIL';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 8d5de825-8791-4d81-b193-c6a7165c4e0f se ha omitido; no se cambiará el nombre del elemento [dbo].[USUARIO_BUSQUEDA].[Id] (SqlSimpleColumn) a PK_USUARIO';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 3186a4f7-16cc-4c42-ad3f-1c6b9be0885a se ha omitido; no se cambiará el nombre del elemento [dbo].[BUSQUEDAS].[Id] (SqlSimpleColumn) a ID_BUSQUEDA';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 98e4d801-14f3-43ec-9f7f-143dd7165b9b se ha omitido; no se cambiará el nombre del elemento [dbo].[USUARIOS].[A_MATERNO] (SqlSimpleColumn) a A_MATERO';


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
    [APELLIDOS]       NVARCHAR (50) NOT NULL,
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
-- Paso de refactorización para actualizar el servidor de destino con los registros de transacciones implementadas

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '9f7d4e73-04fc-40a7-9a3a-f5e1d0f08ac0')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('9f7d4e73-04fc-40a7-9a3a-f5e1d0f08ac0')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8d5de825-8791-4d81-b193-c6a7165c4e0f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8d5de825-8791-4d81-b193-c6a7165c4e0f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3186a4f7-16cc-4c42-ad3f-1c6b9be0885a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3186a4f7-16cc-4c42-ad3f-1c6b9be0885a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4847e470-02ab-4030-97dd-e64606a17796')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4847e470-02ab-4030-97dd-e64606a17796')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '69d951c6-69fa-46f2-b091-8f897ed9bdc6')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('69d951c6-69fa-46f2-b091-8f897ed9bdc6')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5265df91-fb96-4cde-bae0-1ff44ef74cae')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5265df91-fb96-4cde-bae0-1ff44ef74cae')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '98e4d801-14f3-43ec-9f7f-143dd7165b9b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('98e4d801-14f3-43ec-9f7f-143dd7165b9b')

GO

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
