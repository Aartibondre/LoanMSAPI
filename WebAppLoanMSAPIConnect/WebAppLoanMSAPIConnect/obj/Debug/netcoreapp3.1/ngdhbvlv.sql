IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [PropertyInformation] (
    [PropertyNo] int NOT NULL IDENTITY,
    [PropertyType] nvarchar(20) NOT NULL,
    [OwnerName] nvarchar(20) NOT NULL,
    [PropertyProofNo] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_PropertyInformation] PRIMARY KEY ([PropertyNo])
);

GO

CREATE TABLE [BorrowerInformation] (
    [BorrowerId] int NOT NULL IDENTITY,
    [BorrowerName] nvarchar(50) NOT NULL,
    [BorrowerContact] nvarchar(10) NOT NULL,
    [BorrowerAddress] nvarchar(30) NOT NULL,
    [PropertyNo] int NOT NULL,
    [PropertyInformationPropertyNo] int NULL,
    CONSTRAINT [PK_BorrowerInformation] PRIMARY KEY ([BorrowerId]),
    CONSTRAINT [FK_BorrowerInformation_PropertyInformation_PropertyInformationPropertyNo] FOREIGN KEY ([PropertyInformationPropertyNo]) REFERENCES [PropertyInformation] ([PropertyNo]) ON DELETE NO ACTION
);

GO

CREATE TABLE [LegalDocuments] (
    [ApplicationNo] int NOT NULL IDENTITY,
    [GuarantorName] nvarchar(50) NOT NULL,
    [IdentityProof] nvarchar(20) NOT NULL,
    [PropertyProof] nvarchar(20) NOT NULL,
    [OwnershipDocument] nvarchar(20) NOT NULL,
    [PropertyNo] int NOT NULL,
    [PropertyInformationPropertyNo] int NULL,
    CONSTRAINT [PK_LegalDocuments] PRIMARY KEY ([ApplicationNo]),
    CONSTRAINT [FK_LegalDocuments_PropertyInformation_PropertyInformationPropertyNo] FOREIGN KEY ([PropertyInformationPropertyNo]) REFERENCES [PropertyInformation] ([PropertyNo]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_BorrowerInformation_PropertyInformationPropertyNo] ON [BorrowerInformation] ([PropertyInformationPropertyNo]);

GO

CREATE INDEX [IX_LegalDocuments_PropertyInformationPropertyNo] ON [LegalDocuments] ([PropertyInformationPropertyNo]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221129174000_FirstMig', N'3.1.30');

GO

