USE STGenetics;
GO

SELECT Sex, COUNT(AnimalId) Quantity
FROM Animal
GROUP BY Sex
