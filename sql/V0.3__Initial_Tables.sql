USE [datasystem]
GO

CREATE TABLE [dbo].[countries] (
	id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
  country_external_id uniqueidentifier NOT NULL DEFAULT NEWID(),
  country_name nvarchar(MAX) NOT NULL
)