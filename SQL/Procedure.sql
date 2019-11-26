-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.Insert_Execution_Log
	@arg_log_type varchar(30)
	,@arg_log_detail varchar(1000)
	,@arg_last_mod_user varchar(30)
	,@arg_last_mod_date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	insert into dbo.EXECUTION_LOG (LOG_TYPE,LOG_DETAILS,LAST_MOD_USER,LAST_MOD_DATE)
	SELECT @arg_log_type, @arg_log_detail, @arg_last_mod_user, @arg_last_mod_date

END
GO
