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
