IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [BorrowerInformation] (
    [BorrowerId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(20) NOT NULL,
    [LastName] nvarchar(20) NOT NULL,
    [Contact] nvarchar(10) NOT NULL,
    [Dob] datetime2 NOT NULL,
    [Gender] nvarchar(max) NULL,
    [Occupation] nvarchar(max) NOT NULL,
    [IdentityType] nvarchar(max) NOT NULL,
    [IdentiyId] nvarchar(max) NOT NULL,
    [Address] nvarchar(50) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [State] nvarchar(max) NOT NULL,
    [ZipCode] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_BorrowerInformation] PRIMARY KEY ([BorrowerId])
);

GO

CREATE TABLE [Contact] (
    [Id] int NOT NULL IDENTITY,
    [Full_Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [LegalDocuments] (
    [ApplicationNo] int NOT NULL IDENTITY,
    [PropertyProof] nvarchar(50) NULL,
    [BankSalarySlip] nvarchar(50) NOT NULL,
    [AddressProof] nvarchar(50) NOT NULL,
    [GuarantorName] nvarchar(50) NOT NULL,
    [GuarantorProofType] nvarchar(50) NOT NULL,
    [GuarantorProofId] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_LegalDocuments] PRIMARY KEY ([ApplicationNo])
);

GO

CREATE TABLE [PropertyInformation] (
    [ApplicantId] int NOT NULL IDENTITY,
    [LoanType] nvarchar(20) NOT NULL,
    [LoanPurpose] nvarchar(max) NOT NULL,
    [RequestAmount] float NOT NULL,
    [LoanTenure] int NOT NULL,
    CONSTRAINT [PK_PropertyInformation] PRIMARY KEY ([ApplicantId])
);

GO

CREATE TABLE [UserDetails] (
    [Id] int NOT NULL IDENTITY,
    [UserNameOrEmail] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Confirm_Password] nvarchar(max) NULL,
    CONSTRAINT [PK_UserDetails] PRIMARY KEY ([Id])
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Confirm_Password', N'Password', N'UserNameOrEmail') AND [object_id] = OBJECT_ID(N'[UserDetails]'))
    SET IDENTITY_INSERT [UserDetails] ON;
INSERT INTO [UserDetails] ([Id], [Confirm_Password], [Password], [UserNameOrEmail])
VALUES (1, NULL, N'A@123', N'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Confirm_Password', N'Password', N'UserNameOrEmail') AND [object_id] = OBJECT_ID(N'[UserDetails]'))
    SET IDENTITY_INSERT [UserDetails] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221206062115_FirstMig', N'3.1.30');

GO

