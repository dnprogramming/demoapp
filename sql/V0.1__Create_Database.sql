USE [master]
GO
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'datasystem')
  BEGIN
    CREATE DATABASE [datasystem]
  END
GO