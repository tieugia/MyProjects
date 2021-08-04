USE [ecopay]
GO
/****** Object:  StoredProcedure [dbo].[uspExportFileGetInfoSerial]    Script Date: 6/18/2021 6:22:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspExportFileGetInfoSerial] 
    @FromDate datetime = NULL,              -- bat buoc
    @ToDate datetime = NULL,                -- bat buoc
    @ServiceID bigint = NULL,
    @ServiceIDs nvarchar(250) = NULL,       -- ví dụ truyền (truyền theo list cấu hình): "1,2,3"    
    @AgentIDs nvarchar(250) = NULL         -- ví dụ truyền (truyền theo list cấu hình): "2200,1122"
    
AS
SET NOCOUNT ON
SET XACT_ABORT ON
DECLARE @Return int
SET @Return = 0
select T.TransactionID, T.CreateDate, T.Info, T.AgentID, T.ServiceID
--try_convert(date,SUBSTRING(T.Info,patindex('%[0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]%',T.Info),10)) as ExpireDate,
--SUBSTRING(T.Info,charindex('"Price":',T.Info)+8,charindex('"ServiceID":',T.Info)-charindex('"Price":',T.Info)-11) as Price,
--SUBSTRING(T.Info, CHARINDEX ('"Serial":"', T.Info, 1) + 10, CHARINDEX ('"Price":', T.Info, 1) - CHARINDEX ('"Serial":"', T.Info, 1) - 12) AS Serial
from [dbo].[Transaction] T
where (@FromDate IS NULL OR T.CreateDate >= @FromDate)
    AND (@ToDate IS NULL OR T.CreateDate <= @ToDate)
    AND (@ServiceIDs IS NULL OR charindex(',' + convert(varchar, T.ServiceID) + ',', ',' + @ServiceIDs + ',') > 0)
    AND T.Status = 3
    AND T.Amount > 1
    AND (@AgentIDs IS NULL OR charindex(',' + convert(varchar, T.AgentID) + ',', ',' + @AgentIDs + ',') > 0)
order by T.CreateDate desc
RETURN 1
ERROR: 
    RETURN @Return