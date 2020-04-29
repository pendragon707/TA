USE [TA]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Vehicle_Reg]

SELECT	@return_value as 'Return Value'

GO
