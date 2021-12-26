CREATE TABLE Member(
	MemberId VARCHAR(64) NOT NULL PRIMARY KEY,
	Username VARCHAR(16) NOT NULL UNIQUE,
	Password VARBINARY(64) NOT NULL,
	Email VARCHAR(64) NOT NULL,
	Gender BIT NOT NULL,
	Token CHAR(32)
)
GO
CREATE PROC AddMember(
	@MemberId VARCHAR(64),
	@UserName VARCHAR(16),
	@Password VARBINARY(64),
	@Email VARCHAR(64),
	@Gender BIT
)
AS
	INSERT INTO Member (MemberId, Username, Password, Email, Gender)
		VALUES (@MemberId, @UserName, @Password, @Email, @Gender)
GO
CREATE PROC LoginMember(
	@Username VARCHAR(16),
	@Password VARBINARY(64)
)
AS
	SELECT MemberId, Username, Email, Gender FROM Member
		WHERE Username = @Username AND Password = @Password
GO
CREATE PROC LoginMember(
	@Username VARCHAR(16),
	@Password VARBINARY(64)
)AS
	SELECT MemberId,Username,Email,Gender FROM Member
	WHERE Username = @Username AND Password = @Password
GO
CREATE TABLE Role(
	RoleId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	RoleName VARCHAR(16) NOT NULL UNIQUE
);
GO
--DROP TABLE MemberInRole;
GO
CREATE TABLE MemberInRole(
	MemberId VARCHAR(64) NOT NULL REFERENCES Member(MemberId),
	RoleId UNIQUEIDENTIFIER NOT NULL REFERENCES Role(RoleId),
	IsDeleted BIT NOT NULL DEFAULT 0,
	PRIMARY KEY (MemberId,RoleId)
);
go
--DROP PROC SaveMemberInRole;
GO
CREATE PROC SaveMemberInRole(
	@MemberId VARCHAR(64),
	@RoleId UNIQUEIDENTIFIER
)
AS
BEGIN
	IF EXISTS (SELECT * FROM MemberInRole WHERE MemberId = @MemberId AND RoleId = @RoleId)
		UPDATE MemberInRole SET IsDeleted = ~IsDeleted WHERE MemberId = @MemberId AND RoleId = @RoleId
		ELSE 
			INSERT INTO MemberInRole (MemberId, RoleId) VALUES (@MemberId,@RoleId);
END
GO

SELECT Role.*,IIF(MemberId IS NULL,0,1) AS Checked
	FROM MemberInRole RIGHT JOIN Role
	ON MemberInRole.RoleId = Role.RoleId AND 
		MemberId='kbh6s5ho5uw0dttkfcealdfnh916q3edkyh0hojwl8sqoavoy8lzyu2ya2jfrzow';
GO
--Drop PROC GetAllRolesByMemberId;
go
CREATE PROC GetAllRolesByMemberId(@Id VARCHAR(64))
AS
SELECT Role.*,IIF(MemberId IS NULL,0,1) AS Checked
	FROM MemberInRole RIGHT JOIN Role
	ON MemberInRole.RoleId = Role.RoleId AND
	MemberId = @Id AND IsDeleted = 0;
GO

EXEC GetRolesByMemberId @Id = 'kbh6s5ho5uw0dttkfcealdfnh916q3edkyh0hojwl8sqoavoy8lzyu2ya2jfrzow';
GO
--DROP PROC GetRolesByMemberId;
GO
CREATE PROC GetRolesByMemberId(@Id VARCHAR(64))
AS
	SELECT RoleName FROM Role JOIN MemberInRole ON Role.RoleId = MemberInRole.RoleId
		WHERE MemberId = @Id AND IsDeleted = 0;
GO
--DROP PROC GetRolesByMemberId
--GO
--CREATE PROC GetRolesByMemberId(@Id VARCHAR(64))
--AS
--	SELECT Role.*, IIF(MemberId IS NULL, 0, 1) AS Checked
--		FROM MemberInRole RIGHT JOIN Role
--		ON MemberInRole.RoleId = Role.RoleId
--		AND MemberId = @Id
--GO
CREATE TABLE Access (
	AccessId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	RoleId UNIQUEIDENTIFIER NOT NULL REFERENCES Role(RoleId),
	AccessName NVARCHAR(32) NOT NULL,
	AccessUrl VARCHAR(32) NOT NULL UNIQUE
);
GO
CREATE PROC AddAccess(
	@RoleId UNIQUEIDENTIFIER,
	@Name NVARCHAR(32),
	@Url VARCHAR(32)
)
AS
	INSERT INTO Access (RoleId,AccessName,AccessUrl) VALUES(@RoleId,@Name,@Url);
GO
--DROP PROC GetAccesses
GO
CREATE PROC GetAccesses
AS 
	SELECT Access.*,RoleName FROM Access JOIN Role ON Role.RoleId=Access.RoleId;
GO
--Drop Proc GetAccessesByMemberId;
GO
CREATE PROC GetAccessesByMemberId(@Id VARCHAR(64))
AS 
	SELECT * FROM Access JOIN MemberInRole
		ON Access.RoleId = MemberInRole.RoleId AND MemberId = @Id AND IsDeleted =0;
GO
CREATE PROC UpdateMemberToken(
	@Email VARCHAR(64),
	@Token VARCHAR(32)
)
AS 
	UPDATE Member SET Token = @Token WHERE Email = @Email;
GO
CREATE PROC RecoveryPassword(
	@Token VARCHAR(32),
	@Password VARBINARY(64)
)
AS
	UPDATE Member SET Password = @Password, Token = NULL WHERE Token = @Token;
GO
CREATE TABLE Image(
	ImageId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ImageOriginal NVARCHAR(64) NOT NULL,
	ImageUrl VARCHAR(32) NOT NULL,
	ImageType VARCHAR(16) NOT NULL,
	ImageSize BIGINT NOT NULL,
)
go
Create table Pdf(
	PdfId int not null primary key identity(1,1),
	PdfUrl varchar(32) not null,
	Size bigint not null
)
GO
--drop proc StatisticDistricts
go
CREATE PROC StatisticDistricts
AS
SELECT TOP 10 ProvinceName AS Name, COUNT(*) AS Total FROM District
JOIN Province ON Province.ProvinceId = District.ProvinceId
GROUP BY Province.ProvinceId, ProvinceName
GO
CREATE TABLE SalesRestaurant(
	Quantity INT NOT NULL,
	Sales INT NOT NULL
);
GO
INSERT INTO SalesRestaurant (Quantity, Sales) VALUES
(2,58),
(6,105),
(8,118),
(12,117),
(8,88),
(16,137),
(20,157),
(20,169),
(22,149),
(26,202);
GO
--DROP PROC GetSalesRestaurants
GO
CREATE PROC GetSalesRestaurants(
	@Slope FLOAT OUT,
	@Intercept FLOAT OUT
)
AS
BEGIN
	SELECT * FROM SalesRestaurant
	DECLARE @XBar FLOAT, @YBar FLOAT
	SELECT @XBar = AVG(Quantity), @YBar = AVG(Sales) FROM SalesRestaurant
	SELECT @Slope = SUM((Quantity - @XBar) * (Sales - @YBar)) / SUM(POWER(Quantity - @XBar, 2)) FROM SalesRestaurant
	SET @Intercept = @YBar - @Slope * @XBar
END
GO
CREATE TABLE SalesRecord(
	Region VARCHAR(64),
	Country VARCHAR(64),
	ItemType VARCHAR(32),	
	SalesChannel VARCHAR(16),
	OrderPriority VARCHAR(4),
	OrderDate DATE,
	OrderID INT,
	ShipDate DATE,
	UnitsSold DECIMAL(10, 2),
	UnitPrice DECIMAL(10, 2),
	UnitCost DECIMAL(10, 2),
	TotalRevenue DECIMAL(10, 2),
	TotalCost DECIMAL(10, 2),
	TotalProfit DECIMAL(10, 2)
);
GO
BULK INSERT SalesRecord
FROM 'D:\MyProjects\Demo\WebAppVietnam\Script\100 Sales Records.csv'
WITH
(
	FIRSTROW = 2, -- as 1st one is header
	FIELDTERMINATOR = ',', -- CSV field delimiter
	ROWTERMINATOR = '\n',  -- Use to shift the control to next row
	MAXERRORS = 20000
);
GO
CREATE PROC StatisticSalesRecord
AS
	SELECT YEAR(ShipDate) AS [Year], SUM(TotalRevenue) AS Revenue, SUM(TotalCost) AS Expense, SUM(TotalProfit) AS Profit
	FROM SalesRecord GROUP BY YEAR(ShipDate)
GO