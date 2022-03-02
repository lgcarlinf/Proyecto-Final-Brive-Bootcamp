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
El tipo de la columna PASSWORD en la tabla [dbo].[USUARIOS] es  VARCHAR (200) NOT NULL, pero se va a cambiar a  NCHAR (10) NOT NULL. Si la columna contiene datos no compatibles con el tipo  NCHAR (10) NOT NULL, podrían producirse pérdidas de datos y errores en la implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[USUARIOS])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
PRINT N'La siguiente operación se generó a partir de un archivo de registro de refactorización 4d8f0f67-868a-4896-9692-440cb108e67e';

PRINT N'Cambiar el nombre de [dbo].[BUSQUEDAS].[ID_BUSQUEDA] a IDBUSQUEDA';


GO
EXECUTE sp_rename @objname = N'[dbo].[BUSQUEDAS].[ID_BUSQUEDA]', @newname = N'IDBUSQUEDA', @objtype = N'COLUMN';


GO
PRINT N'La siguiente operación se generó a partir de un archivo de registro de refactorización a81a3b5d-383e-4afb-a23b-c2cc8231106b';

PRINT N'Cambiar el nombre de [dbo].[BUSQUEDAS].[EMPRESA_BUSCADA] a EMPRESABUSCADA';


GO
EXECUTE sp_rename @objname = N'[dbo].[BUSQUEDAS].[EMPRESA_BUSCADA]', @newname = N'EMPRESABUSCADA', @objtype = N'COLUMN';


GO
PRINT N'La siguiente operación se generó a partir de un archivo de registro de refactorización 15f98060-1400-45a9-b12a-d25814276d46';

PRINT N'Cambiar el nombre de [dbo].[BUSQUEDAS].[RESULTADO_BUSQUEDA] a RESULTADOBUSQUEDA';


GO
EXECUTE sp_rename @objname = N'[dbo].[BUSQUEDAS].[RESULTADO_BUSQUEDA]', @newname = N'RESULTADOBUSQUEDA', @objtype = N'COLUMN';


GO
PRINT N'La siguiente operación se generó a partir de un archivo de registro de refactorización 6505c3ee-84a9-40ab-b3df-8b76b44ff5aa';

PRINT N'Cambiar el nombre de [dbo].[BUSQUEDAS].[FECHA_BUSQUEDA] a FECHABUSQUEDA';


GO
EXECUTE sp_rename @objname = N'[dbo].[BUSQUEDAS].[FECHA_BUSQUEDA]', @newname = N'FECHABUSQUEDA', @objtype = N'COLUMN';


GO
PRINT N'Modificando Tabla [dbo].[USUARIOS]...';


GO
ALTER TABLE [dbo].[USUARIOS] ALTER COLUMN [PASSWORD] NCHAR (10) NOT NULL;


GO
-- Paso de refactorización para actualizar el servidor de destino con los registros de transacciones implementadas
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4d8f0f67-868a-4896-9692-440cb108e67e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4d8f0f67-868a-4896-9692-440cb108e67e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a81a3b5d-383e-4afb-a23b-c2cc8231106b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a81a3b5d-383e-4afb-a23b-c2cc8231106b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '15f98060-1400-45a9-b12a-d25814276d46')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('15f98060-1400-45a9-b12a-d25814276d46')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6505c3ee-84a9-40ab-b3df-8b76b44ff5aa')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6505c3ee-84a9-40ab-b3df-8b76b44ff5aa')

GO

GO
PRINT N'Actualización completada.';


GO
