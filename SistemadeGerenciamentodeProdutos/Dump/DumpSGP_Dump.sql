IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(200) NOT NULL,
    [Descricao] nvarchar(max) NULL,
    [PrecoUnitario] decimal(18,2) NOT NULL,
    [QuantidadeEstoque] int NOT NULL,
    [Ativo] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251125135344_InitialCreate', N'8.0.3');
GO

COMMIT;
GO

