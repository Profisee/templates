PRINT 'Removing jSync_BaseGovern SQL Agent Job...'
GO

IF  EXISTS (SELECT job_id FROM msdb.dbo.sysjobs_view WHERE name = N'jSync_BaseGovern')
	EXEC msdb.dbo.sp_delete_job @job_name=N'jSync_BaseGovern', @delete_unused_schedule=1
GO

PRINT 'Removing base_pSync_Govern Stored Procedure...'
GO

IF (SELECT OBJECT_ID(N'gov.base_pSync_Govern')) IS NOT NULL
BEGIN
	DROP PROCEDURE gov.base_pSync_Govern
	DROP SCHEMA [gov]
END
GO
