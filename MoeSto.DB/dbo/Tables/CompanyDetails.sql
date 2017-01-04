CREATE TABLE [dbo].[CompanyDetails] (
    [Id]                    INT            NOT NULL,
    [Name]                  NVARCHAR (MAX) NOT NULL,
    [Unp]                   INT            NULL,
    [CatalogUrl]            NVARCHAR (MAX) NULL,
    [Address]               NVARCHAR (MAX) NULL,
    [Email]                 NVARCHAR (MAX) NULL,
    [Phones]                NVARCHAR (MAX) NULL,
    [FoundOnCardone]        BIT            NULL,
    [CardoneStatus]         NVARCHAR (MAX) NULL,
    [CardoneContractNo]     INT            NULL,
    [CardoneContractStatus] NVARCHAR (MAX) NULL,
    [Latitude]              FLOAT (53)     NOT NULL,
    [Longitude]             FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_CompanyDetails] PRIMARY KEY CLUSTERED ([Id] ASC)
);

