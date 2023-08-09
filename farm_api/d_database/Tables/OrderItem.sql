CREATE TABLE [dbo].[OrderItem] (
        [OrderItemId]	INT NOT NULL PRIMARY KEY IDENTITY,
        [OrderId]		INT NOT NULL,
        [AnimalId]		INT NOT NULL,
        [Quantity]		INT NOT NULL,
        [UnitPrice]		DECIMAL (18, 2) NOT NULL,	-- save purchase value in case it changes afterwards
		[Discount]		DECIMAL (18, 2) NOT NULL,
		[Price]			DECIMAL (18, 2) NOT NULL,
		FOREIGN KEY ([OrderId]) REFERENCES [Order]([OrderId]),
		FOREIGN KEY ([AnimalId]) REFERENCES [Animal]([AnimalId]),
    );
