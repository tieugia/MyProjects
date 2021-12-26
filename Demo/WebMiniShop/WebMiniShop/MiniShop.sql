CREATE DATABASE MiniShop;
GO
USE MiniShop;
GO
--DROP TABLE Category;
GO
CREATE TABLE Category(
	CategoryId TINYINT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	CategoryName NVARCHAR(32) NOT NULL
);
GO
INSERT INTO Category (CategoryName) VALUES
	('Men'), ('Women'), ('Kids');
GO