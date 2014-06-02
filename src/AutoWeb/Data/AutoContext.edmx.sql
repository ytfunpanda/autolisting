
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2014 18:54:19
-- Generated from EDMX file: C:\dev\autolisting\src\AutoWeb\Data\AutoContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AutoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Listing_StatusType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Listings] DROP CONSTRAINT [FK_Listing_StatusType];
GO
IF OBJECT_ID(N'[dbo].[FK_webpages_UsersInRoles_webpages_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [FK_webpages_UsersInRoles_webpages_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_webpages_UsersInRoles_UserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [FK_webpages_UsersInRoles_UserProfile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Languages];
GO
IF OBJECT_ID(N'[dbo].[Listings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Listings];
GO
IF OBJECT_ID(N'[dbo].[StatusTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatusTypes];
GO
IF OBJECT_ID(N'[dbo].[UserProfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfiles];
GO
IF OBJECT_ID(N'[dbo].[VehicleTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleTypes];
GO
IF OBJECT_ID(N'[dbo].[webpages_Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Membership];
GO
IF OBJECT_ID(N'[dbo].[webpages_OAuthMembership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_OAuthMembership];
GO
IF OBJECT_ID(N'[dbo].[webpages_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Roles];
GO
IF OBJECT_ID(N'[dbo].[FuelTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuelTypes];
GO
IF OBJECT_ID(N'[dbo].[webpages_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_UsersInRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [LanguageID] int IDENTITY(1,1) NOT NULL,
    [Lang] char(2)  NULL,
    [Name] nvarchar(50)  NULL,
    [English] nvarchar(50)  NULL
);
GO

-- Creating table 'Listings'
CREATE TABLE [dbo].[Listings] (
    [ListingID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [DateAdd] datetime  NULL,
    [Title] varchar(200)  NULL,
    [VIN] int  NULL,
    [Year] int  NULL,
    [MakeID] int  NULL,
    [ModelID] int  NULL,
    [Trim] varchar(50)  NULL,
    [BodyStyleID] int  NULL,
    [TransmissionID] int  NULL,
    [ShowVIN] bit  NULL,
    [IsCertified] bit  NULL,
    [IsETested] bit  NULL,
    [StatusID] int  NULL,
    [Price] decimal(18,0)  NULL,
    [KM] int  NULL,
    [BodyColorID] int  NULL,
    [InteriorColorID] int  NULL,
    [DoorCountID] int  NULL,
    [PassengerCountID] int  NULL,
    [DriveTrainID] int  NULL,
    [Engine] varchar(50)  NULL,
    [CylinderCount] int  NULL,
    [FuelTypeID] int  NULL,
    [StatusTypeID] int  NULL,
    [Location] varchar(50)  NULL
);
GO

-- Creating table 'StatusTypes'
CREATE TABLE [dbo].[StatusTypes] (
    [StatusTypeID] int IDENTITY(1,1) NOT NULL,
    [Lang] char(2)  NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'UserProfiles'
CREATE TABLE [dbo].[UserProfiles] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(56)  NOT NULL
);
GO

-- Creating table 'VehicleTypes'
CREATE TABLE [dbo].[VehicleTypes] (
    [VehicleTypeID] int IDENTITY(1,1) NOT NULL,
    [Lang] char(2)  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [SortOrder] int  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'webpages_Membership'
CREATE TABLE [dbo].[webpages_Membership] (
    [UserId] int  NOT NULL,
    [CreateDate] datetime  NULL,
    [ConfirmationToken] nvarchar(128)  NULL,
    [IsConfirmed] bit  NULL,
    [LastPasswordFailureDate] datetime  NULL,
    [PasswordFailuresSinceLastSuccess] int  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordChangedDate] datetime  NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [PasswordVerificationToken] nvarchar(128)  NULL,
    [PasswordVerificationTokenExpirationDate] datetime  NULL
);
GO

-- Creating table 'webpages_OAuthMembership'
CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [Provider] nvarchar(30)  NOT NULL,
    [ProviderUserId] nvarchar(100)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'webpages_Roles'
CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'FuelTypes'
CREATE TABLE [dbo].[FuelTypes] (
    [FuelTypeID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'webpages_UsersInRoles'
CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [webpages_Roles_RoleId] int  NOT NULL,
    [UserProfiles_UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LanguageID] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([LanguageID] ASC);
GO

-- Creating primary key on [ListingID] in table 'Listings'
ALTER TABLE [dbo].[Listings]
ADD CONSTRAINT [PK_Listings]
    PRIMARY KEY CLUSTERED ([ListingID] ASC);
GO

-- Creating primary key on [StatusTypeID] in table 'StatusTypes'
ALTER TABLE [dbo].[StatusTypes]
ADD CONSTRAINT [PK_StatusTypes]
    PRIMARY KEY CLUSTERED ([StatusTypeID] ASC);
GO

-- Creating primary key on [UserId] in table 'UserProfiles'
ALTER TABLE [dbo].[UserProfiles]
ADD CONSTRAINT [PK_UserProfiles]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [VehicleTypeID] in table 'VehicleTypes'
ALTER TABLE [dbo].[VehicleTypes]
ADD CONSTRAINT [PK_VehicleTypes]
    PRIMARY KEY CLUSTERED ([VehicleTypeID] ASC);
GO

-- Creating primary key on [UserId] in table 'webpages_Membership'
ALTER TABLE [dbo].[webpages_Membership]
ADD CONSTRAINT [PK_webpages_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Provider], [ProviderUserId] in table 'webpages_OAuthMembership'
ALTER TABLE [dbo].[webpages_OAuthMembership]
ADD CONSTRAINT [PK_webpages_OAuthMembership]
    PRIMARY KEY CLUSTERED ([Provider], [ProviderUserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'webpages_Roles'
ALTER TABLE [dbo].[webpages_Roles]
ADD CONSTRAINT [PK_webpages_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [FuelTypeID] in table 'FuelTypes'
ALTER TABLE [dbo].[FuelTypes]
ADD CONSTRAINT [PK_FuelTypes]
    PRIMARY KEY CLUSTERED ([FuelTypeID] ASC);
GO

-- Creating primary key on [webpages_Roles_RoleId], [UserProfiles_UserId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [PK_webpages_UsersInRoles]
    PRIMARY KEY NONCLUSTERED ([webpages_Roles_RoleId], [UserProfiles_UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StatusTypeID] in table 'Listings'
ALTER TABLE [dbo].[Listings]
ADD CONSTRAINT [FK_Listing_StatusType]
    FOREIGN KEY ([StatusTypeID])
    REFERENCES [dbo].[StatusTypes]
        ([StatusTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Listing_StatusType'
CREATE INDEX [IX_FK_Listing_StatusType]
ON [dbo].[Listings]
    ([StatusTypeID]);
GO

-- Creating foreign key on [webpages_Roles_RoleId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [FK_webpages_UsersInRoles_webpages_Roles]
    FOREIGN KEY ([webpages_Roles_RoleId])
    REFERENCES [dbo].[webpages_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserProfiles_UserId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [FK_webpages_UsersInRoles_UserProfile]
    FOREIGN KEY ([UserProfiles_UserId])
    REFERENCES [dbo].[UserProfiles]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_webpages_UsersInRoles_UserProfile'
CREATE INDEX [IX_FK_webpages_UsersInRoles_UserProfile]
ON [dbo].[webpages_UsersInRoles]
    ([UserProfiles_UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------