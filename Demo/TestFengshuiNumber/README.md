create database Fengshui
USE [Fengshui]
GO

/****** Object:  Table [dbo].[phoneNumber]    Script Date: 18/08/2021 9:50:42 CH ******/
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
