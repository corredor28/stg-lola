USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'STGenetics')
BEGIN
	CREATE DATABASE STGenetics;
END;
GO
