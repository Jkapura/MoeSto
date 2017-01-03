CREATE TABLE [dbo].[Image] (
    [CompanyId] INT   NOT NULL,
    [ImageId]   INT   NOT NULL,
    [Image]     IMAGE NULL,
    CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED ([ImageId] ASC),
    CONSTRAINT [FK_Image_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id])
);

