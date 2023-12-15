USE [datasystem]
GO
CREATE PROCEDURE dbo.uspInsertCountry
  @country_name nvarchar(200)
AS

  INSERT INTO [dbo].[countries] (country_name)
  VALUES(EncryptByAsymKey(AsymKey_ID('data_storage'), @country_name))
GO

CREATE PROCEDURE dbo.uspGetAllCountries
  @passkey nvarchar(MAX)
AS
  SELECT 
    country_external_id,
    DecryptByAsymKey(AsymKey_ID('data_storage'), country_name, @passkey) AS country_name
  FROM
    [dbo].[countries]
GO

CREATE PROCEDURE dbo.uspGetCountry
  @passkey nvarchar(MAX),
  @country_id int
AS
  SELECT 
    country_external_id,
    DecryptByAsymKey(AsymKey_ID('data_storage'), country_name, @passkey) AS country_name
  FROM
    [dbo].[countries]
  WHERE
    id = @country_id
GO
