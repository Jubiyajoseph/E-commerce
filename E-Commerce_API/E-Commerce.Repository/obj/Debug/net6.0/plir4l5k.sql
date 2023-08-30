BEGIN TRANSACTION;
GO

ALTER SCHEMA [dbo] TRANSFER [User];
GO

ALTER TABLE [dbo].[User] ADD [PeriodEnd] datetime2 NOT NULL DEFAULT '9999-12-31T23:59:59.9999999';
GO

ALTER TABLE [dbo].[User] ADD [PeriodStart] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [dbo].[User] ADD PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd])
GO

ALTER TABLE [dbo].[User] ALTER COLUMN [PeriodStart] ADD HIDDEN
GO

ALTER TABLE [dbo].[User] ALTER COLUMN [PeriodEnd] ADD HIDDEN
GO

ALTER TABLE [dbo].[User] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dboHT].[User]))

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230830102230_addedConfiguration1', N'6.0.21');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[User]') AND [c].[name] = N'Phone');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[User] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [dbo].[User] ALTER COLUMN [Phone] nvarchar(12) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[User]') AND [c].[name] = N'Password');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[User] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [dbo].[User] ALTER COLUMN [Password] nvarchar(15) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[User]') AND [c].[name] = N'Name');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[User] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [dbo].[User] ALTER COLUMN [Name] nvarchar(50) NOT NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[User]') AND [c].[name] = N'Email');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[User] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [dbo].[User] ALTER COLUMN [Email] nvarchar(50) NOT NULL;
GO

CREATE UNIQUE INDEX [IX_User_Email] ON [dbo].[User] ([Email]);
GO

CREATE INDEX [IX_User_Name] ON [dbo].[User] ([Name]);
GO

CREATE UNIQUE INDEX [IX_User_Phone] ON [dbo].[User] ([Phone]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230830102457_addedConfiguration2', N'6.0.21');
GO

COMMIT;
GO

