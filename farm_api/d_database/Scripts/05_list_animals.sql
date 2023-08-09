USE STGenetics;
GO

SELECT * 
FROM Animal
WHERE BirthDate < DATEADD(YEAR, -2, GETDATE())	-- older than 2 years
	AND Sex = 'Female'							-- and female
ORDER BY Name									-- sorted by name
