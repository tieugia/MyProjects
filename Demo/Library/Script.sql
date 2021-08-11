select * from [dbo].[Diary]
select * from [dbo].[User]

CREATE TABLE Book(
	BookId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	BookName NVARCHAR(32)
);
INSERT INTO Book (BookName) VALUES
	('Toeic'), ('IELTS'), ('Hacker');
GO
--DROP TABLE Diary;
GO
CREATE TABLE Diary(
	DiaryId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	BookId INT NOT NULL REFERENCES Book(BookId),
	UserId INT NOT NULL REFERENCES [User](UserId),
	Amount INT NOT NULL,
	BorrowDate DATETIME NOT NULL,
	ReturnDate DATETIME,
	ExpiredDate DATETIME NOT NULL
);

INSERT INTO Diary(UserID, BookId, Amount, BorrowDate, ReturnDate, ExpiredDate) VALUES
	(1, 1, 3, '2021/8/8', NULL, '2021/8/9'),
	(1, 2, 2, '2021/8/8', NULL, '2021/8/9'),
	(1, 3, 1, '2021/8/8', NULL, '2021/8/9');


select * from Diary;
select * from [dbo].[User]
select * from [dbo].[Book]
