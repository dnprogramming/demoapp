USE [datasystem]
GO
CREATE PROCEDURE dbo.uspInsertCountry
  @country_name nvarchar(MAX),
  @record_id int OUTPUT
AS
  INSERT INTO [dbo].[countries] (country_name)
  VALUES(EncryptByAsymKey(AsymKey_ID('data_storage'), @country_name))

  SET @record_id = SCOPE_IDENTITY()
  RETURN @record_id
GO

CREATE PROCEDURE dbo.uspGetCountries
  @passkey nvarchar(MAX)
AS
  SELECT 
    country_external_id,
    CAST(DecryptByAsymKey(AsymKey_ID('data_storage'), country_name, @passkey) AS nvarchar(max)) AS country_name
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
