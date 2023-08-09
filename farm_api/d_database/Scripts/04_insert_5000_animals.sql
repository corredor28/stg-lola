USE STGenetics;
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
