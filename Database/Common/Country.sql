CREATE TABLE [Common].[Country]
(
	[CountryId]   int          NOT NULL,
	[CountryCode] varchar (15) NOT NULL,
	[Description] varchar (60) NULL,
	[IsActive]    bit          NOT NULL CONSTRAINT DF_Country_IsActive_No DEFAULT ((0)),
	[Alpha2Code]  varchar(4)   NULL,
	[NumericCode] varchar(4)   NULL,
	
	CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED  ([CountryId])
);
GO

CREATE NONCLUSTERED INDEX [IX_Country_Description]
	ON [Common].[Country] ([Description] ASC) INCLUDE ([CountryCode], [Alpha2Code], [IsActive])
GO

CREATE NONCLUSTERED INDEX [IX_Country_CountryCode]
	ON [Common].[Country] ([CountryCode] ASC) INCLUDE ([Description], [Alpha2Code], [IsActive])
GO

CREATE NONCLUSTERED INDEX [IX_Country_Alpha2Code]
	ON [Common].[Country] ([Alpha2Code] ASC) INCLUDE ([Description], [CountryCode], [IsActive])
GO
