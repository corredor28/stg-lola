USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'STGenetics')
BEGIN
	CREATE DATABASE STGenetics;
END;
GO

USE STGenetics;
GO

IF NOT EXISTS (SELECT * FROM sysobjects where name='Animal' and xtype='U')
BEGIN
    CREATE TABLE [dbo].[Animal] (
        [AnimalId]  INT             NOT NULL PRIMARY KEY IDENTITY, 
        [Name]      NVARCHAR (MAX)  NOT NULL,
        [Breed]     NVARCHAR (MAX)  NOT NULL,
        [BirthDate] DATETIME        NOT NULL,
        [Sex]       NVARCHAR (20)   NOT NULL,
        [Price]     DECIMAL (18, 2) NOT NULL,
        [Status]    NVARCHAR (10)   NOT NULL
    );
END;
GO

USE STGenetics;
GO

INSERT Animal (Name, Breed, BirthDate, Sex, Price, Status)
VALUES ('Lola', 'Black', DATEADD(year, -8, getdate()), 'Female', '400.53', 'Active')

UPDATE Animal SET Breed = 'B&W' WHERE Name = 'Lola'

DELETE Animal WHERE Name = 'Lola'

GO

-- Rows generation: https://stackoverflow.com/a/21264624/1863970
INSERT Animal (Name, Breed, BirthDate, Sex, Price, Status)
SELECT TOP (5000) 
	--ROW_NUMBER() OVER (ORDER BY [object_id])
	'Lola' + LEFT(NEWID(), 8) Name
	, 'BR' + SUBSTRING(CONVERT(VARCHAR(36),NEWID()), 10, 4) Breed
	, DATEADD(year, -1 * ABS(CHECKSUM(NewId())) % 14, getdate()) BirthDate				-- https://stackoverflow.com/a/1045162/1863970
	, CASE ABS(CHECKSUM(NewId())) % 2 WHEN 1 THEN 'Female' ELSE 'Male' END Sex
	, round(rand(checksum(newid()))*(100)+200,2) Price									-- https://stackoverflow.com/a/47155777/1863970
	, CASE ABS(CHECKSUM(NewId())) % 2 WHEN 1 THEN 'Active' ELSE 'Inactive' END Status
FROM sys.all_columns ORDER BY [object_id];

select * from Animal

SELECT * 
FROM Animal
WHERE BirthDate < DATEADD(YEAR, -2, GETDATE())	-- older than 2 years
	AND Sex = 'Female'							-- and female
ORDER BY Name									-- sorted by name

SELECT Sex, COUNT(AnimalId) Quantity
FROM Animal
GROUP BY Sex
