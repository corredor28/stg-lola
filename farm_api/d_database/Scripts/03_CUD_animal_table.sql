USE STGenetics;
GO

INSERT Animal (Name, Breed, BirthDate, Sex, Price, Status)
VALUES ('Lola', 'Black', DATEADD(year, -8, getdate()), 'Female', '400.53', 'Active')

UPDATE Animal SET Breed = 'B&W' WHERE Name = 'Lola'

DELETE Animal WHERE Name = 'Lola'
