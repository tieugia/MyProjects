create database Fengshui
USE [Fengshui]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[phoneNumber](
	[phoneNumber] [varchar](10) NULL
) ON [PRIMARY]
GO

insert into [dbo].[phoneNumber] values ('0937073039')--Not match
insert into [dbo].[phoneNumber] values ('0968322658')--58=>taboo
insert into [dbo].[phoneNumber] values ('0937573099')--Not match
insert into [dbo].[phoneNumber] values ('0967245937')--Not match
insert into [dbo].[phoneNumber] values ('0867392819')--Match

--CREATE FUNCTION
CREATE FUNCTION dbo.udf_SumOfDigits (@DigitString varchar(50))
RETURNS int
AS
BEGIN
 DECLARE @SumOfDigits int = 0;
 WITH
  T4 AS (SELECT 0 x UNION ALL SELECT 0 UNION ALL SELECT 0 UNION ALL SELECT 0),
  Numbers AS (SELECT ROW_NUMBER() OVER(ORDER BY a.x) AS Num FROM T4 a CROSS JOIN T4 b CROSS JOIN T4 c)
 SELECT @SumOfDigits =
  SUM(CASE WHEN SUBSTRING(@DigitString, Num, 1) LIKE '[0-9]'
   THEN CAST(SUBSTRING(@DigitString, Num, 1) AS int)
   ELSE 0 END)
 FROM Numbers
 WHERE Numbers.Num <= LEN(@DigitString);

 RETURN (@SumOfDigits);
END
GO

--Create Stored Procedure
create procedure [dbo].[usplistFengshuinumber]
as
begin
select P.phoneNumber
from (select phoneNumber, LEFT(phoneNumber,3) as first3, 
RIGHT(phoneNumber,2) as last2,
[dbo].[udf_SumOfDigits](Convert(int,LEFT(phoneNumber,5))) as SumLeft,
[dbo].[udf_SumOfDigits](Convert(int,right(phoneNumber,5))) as SumRight
from [dbo].[phoneNumber]) P
where (P.first3='086' or P.first3='096' or P.first3='097' 
or P.first3='089' or P.first3='090' or P.first3='093'
or P.first3='088' or P.first3='091' or P.first3='094')
and (P.SumLeft=24 and P.SumRight=28 or P.SumRight=29)  
and (P.last2='19' or P.last2='24' or P.last2='26' or P.last2='27' or P.last2='34')
end
