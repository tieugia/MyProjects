--Tạo cơ sở dữ liệu--
CREATE DATABASE Lotte;
GO
USE Lotte;
GO
--Tạo bảng tên category
CREATE TABLE Category(
	CategoryId INT NOT NULL PRIMARY KEY IDENTITY(1,1) ,  --IDENTITY là tự tăng dần(giá trị bắt đầu, giá trị bước nhảy)
	CategoryName NVARCHAR(64) NOT NULL
);
GO
--Thêm dữ liệu vào bảng category
INSERT INTO Category (CategoryName)
	VALUES (N'Miền Bắc'), (N'Miền Trung'), (N'Miền Nam');
	GO
--Xóa dữ liệu (Xóa Hết)
--TRUNCATE TABLE Category
--Xem kết quả dữ liệu
--SELECT * FROM Category;
create table Area(
	AreaId smallint not null primary key identity(1,1),
	AreaName nvarchar(64) not null
)
go
insert into Area(AreaName) values 
		('North'), ('West')
-------------------------------------------------------
--SELECT * FROM Area
--DROP PROC GetAreas
--CREATE PROC GetAreas
--as
--select * from Area
--go
create table Province(
ProvinceId smallint not null primary key identity(1,1),
AreaId Smallint not null references Area(AreaId),
ProvinceName nvarchar(64) not null
)
go
insert into Province(AreaId,ProvinceName) values
(1, N'Hà Nội'),
(2, N'Hồ Chí Minh')
go
--drop proc GetProvinces
go
create proc GetProvinces
as
Select Province.*, AreaName from Province join Area on Province.AreaId=Area.AreaId
go
--drop proc AddProvince
go
create proc AddProvince(
@areaId smallint,
@patternId tinyint,
@name nvarchar(64)
)
as
insert into Province(AreaId,ProvinceName,PatternId) values (@areaId, @name, @patternId)
go
create proc EditProvince(
@id smallint,
@areaId smallint,
@name nvarchar(64)
)
as
Update Province SET AreaId=@areaId, ProvinceName=@name
where ProvinceId=@id
go
--create proc GetProvince(@id smallint)
--as
--	select * from Province where ProvinceId=@id
--go
--create table Prize(
--	PrizeId tinyint not null primary key,
--	PrizeName nvarchar(32) not null
--)
--Go
--insert into Prize(PrizeId, PrizeName) values
--	(0,N'Giải ĐB'),
--	(1,N'Giải Nhất')
--go
--Create proc AddPrize(@id tinyint, @name nvarchar(32))
--as 
--	insert into Prize(PrizeId, PrizeName) values (@id, @name)
--go
--create proc GetPrizes
--as 
--select * from Prize
--go

--Made at home--

--create proc GetPrize(@id tinyint)
--as
--	select * from Prize where PrizeId = @id
--go
create proc EditPrize (@id tinyint, @name nvarchar(32))
as
	Update Prize set PrizeName = @name where PrizeId = @id
go
--drop table Number
go
Create table Number(
	NumberId int not null primary key identity(1,1),
	PrizeId tinyint not null references Prize(PrizeId),
	ProvinceId smallint not null references Province(ProvinceId),
	NumberValue varchar(8) not null,
	NumberDate Date not null default GETDATE()
);
go
create proc AddNumber(
	@PrizeId tinyint,
	@ProvinceId smallint,
	@Value nvarchar(8),
	@Date DATE
	)
as
	insert into Number (PrizeId, ProvinceId, NumberValue, NumberDate) values
	(@PrizeId, @ProvinceId, @Value, @Date)
go
create proc GetNumbers
as
	select * from Number
go
Exec AddNumber @PrizeId=0,@ProvinceId=1,@Value='331542',@Date='2021/9/25'
go
create table Result(
	ResultId int not null primary key identity(1,1),
	ResultDate Date not null default GetDate(),
	ProvinceId smallint not null references Province(ProvinceId)
)
go
create proc AddResult(
	@id int out,.
	@date date,
	@provinceId smallint
)
as
begin
	insert into Result(ResultDate, ProvinceId) values
		(@date, @provinceId);
	set @id = SCOPE_IDENTITY()
end
go
create proc GetResults
as
	select Result.*, ProvinceName from Result join Province on Result.ProvinceId=Province.ProvinceId
go
--DROP TABLE [dbo].[Result]
GO
CREATE TABLE [dbo].[Result](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[ResultDate] [date] NOT NULL,
	[ProvinceId] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Result] ADD  DEFAULT (getdate()) FOR [ResultDate]
GO

ALTER TABLE [dbo].[Result]  WITH CHECK ADD FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Province] ([ProvinceId])
GO
--DROP TABLE [dbo].[Number]
GO
CREATE TABLE [dbo].[Number](
	[NumberId] [bigint] IDENTITY(1,1) NOT NULL,
	[PrizeId] [tinyint] NOT NULL,
	[ResultId] [int] NOT NULL,
	[NumberValue] [varchar](8) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Number]  WITH CHECK ADD FOREIGN KEY([PrizeId])
REFERENCES [dbo].[Prize] ([PrizeId])
GO

ALTER TABLE [dbo].[Number]  WITH CHECK ADD FOREIGN KEY([ResultId])
REFERENCES [dbo].[Result] ([ResultId])
GO
create proc [dbo].[GetNumbersByResult](@id int)
as
	Select * from Number where ResultId = @id
go
create proc [dbo].[GetResult](@id int)
as
	select Result.*, ProvinceName from Result join Province 
	on Result.ProvinceId = Province.ProvinceId
		where ResultId=@id
GO
--drop proc GetPrizesAndCount
go
create proc GetPrizesAndCount
as
begin
	select COUNT(*) from Prize;
	select * from Prize;
end
go
--drop table Pattern
create table Pattern(
	PatternId tinyint not null primary key identity(1,1),
	PatternAdd nvarchar(max),
	PatternShow nvarchar(max)
)
go
insert into Pattern (PatternShow, PatternAdd) values (N'<table class="tbl">
    <tr>
        <th>Giải Đặc biệt</th>
        <td colspan="12">{0}</td>
    </tr>
    <tr>
        <th>Giải nhất</th>
        <td colspan="12">{1}</td>
    </tr>
    <tr>
        <th>Giải nhì</th>
        <td colspan="12">{2}</td>
    </tr>
    <tr>
        <th>Giải ba</th>
        <td colspan="6">{3}</td>
        <td colspan="6">{4}</td>
    </tr>
    <tr class="no-border-bottom">
        <th rowspan="2">Giải tư</th>
        <td colspan="3">{5}</td>
        <td colspan="3">{6}</td>
        <td colspan="3">{7}</td>
        <td colspan="3">{8}</td>
    </tr>
    <tr class="no-border-top">
        <td colspan="4">{9}</td>
        <td colspan="4">{10}</td>
        <td colspan="4">{11}</td>
    </tr>
    <tr>
        <th>Giải năm</th>
        <td colspan="12">{12}</td>
    </tr>
    <tr>
        <th>Giải sáu</th>
        <td colspan="4">{13}</td>
        <td colspan="4">{14}</td>
        <td colspan="4">{15}</td>
    </tr>
    <tr>
        <th>Giải bảy</th>
        <td colspan="12">{16}</td>
    </tr>
    <tr>
        <th>Giải tám</th>
        <td colspan="12">{17}</td>
    </tr>
</table>', NULL)
go
--select * from Pattern
--drop table ProvincePattern
create table ProvincePattern(
	ProvinceId smallint not null references Province(ProvinceId),
	PatternId tinyint not null references Pattern(PatternId) 
	primary key (ProvinceId, PatternId)
)
--select * from ProvincePattern
insert into ProvincePattern(ProvinceId, PatternId) values (2, 1)
go
--drop proc GetPatternByProvince
go
create proc GetPatternByProvince(@id smallint)
as
	select Pattern.* from Pattern join Province
	on Pattern.PatternId = Province.PatternId where ProvinceId = @id
go
create proc GetShowByProvince(@id smallint)
as
	select PatternShow from Pattern join Province on Pattern.PatternId = Province.PatternId
	where ProvinceId = @id
go
create proc GetAddByProvince(@id smallint)
as
	select PatternAdd from Pattern join Province on Pattern.PatternId = Province.PatternId
	where ProvinceId = @id
go
create proc GetPatterns
as
	select * from Pattern
go
create proc AddPattern(
	@Show nvarchar(max) = NULL,
	@Add nvarchar(max) = NULL
)
as
	insert into Pattern(PatternShow, PatternAdd) values (@Show, @Add)
go
--alter table Province add PatternId tinyint references Pattern(PatternId)
alter table Province add PatternId tinyint not null default 1 references Pattern(PatternId)
--alter table Province drop column PatternId	
--alter table Province drop constraint FK__Province__Patter__1AD3FDA4	
SELECT * FROM Number WHERE ResultId = 10 ORDER BY PrizeId
--exec GetShowByProvince 1
go
create proc EditPattern(
	@id tinyint,
	@add nvarchar(max) = null,
	@show nvarchar(max) = null
)
as
	update Pattern set PatternShow = @show, PatternAdd = @add where PatternId = @id
go
exec GetPatternByProvince 8
select * from Province
go
--drop proc EditNumber
go
create proc EditNumber(
	@id bigint,
	--@prizeId bigint,
	--@resultId int,
	@Value varchar(8)
) as
	UPDATE Number set NumberValue = @Value
		where NumberId = @id
go
select * from Pattern
exec GetShowByProvince 1
SELECT PrizeId, NumberValue FROM Number WHERE ResultId = 2016 ORDER BY PrizeId;

go
create proc DeleteResult(@id int)
as
begin
	DELETE FROM Number WHERE ResultId = @id;
	DELETE FROM Result WHERE ResultId = @id;
end
go
DELETE Number;
DELETE Result;
DELETE ProvincePattern;
DELETE Province;
--
DELETE FROM Result
DELETE FROM Province
DELETE FROM Number
--
SELECT * FROM Province
SELECT * FROM Area
SELECT * FROM Prize
SELECT * FROM Result
SELECT * FROM Number
--
insert into Area(AreaName) values (N'Miền Nam')
--
SELECT * from Result order by ResultDate desc
	offset 0 rows fetch next 3 rows only
--OFFSET la so thu tu trang
go
create proc GetResultsAndCount(
	@index int,
	@size int,
	@count int out
)
as
begin
	select Result.*, ProvinceName from Result 
		join Province on Result.ProvinceId = Province.ProvinceId
		order by ResultDate desc
		OFFSET @index ROWS FETCH NEXT @size ROWS ONLY;
	SELECT @count = COUNT(*) FROM Result;
end
DECLARE @c INT = 0
EXEC GetResultsAndCount @index = 0, @size = 3, @count = @c out;
PRINT @c
SELECT * FROM Result WHERE ResultDate = FORMAT(GETDATE(), 'yyyy/MM/dd') --> lay ngay hom nay