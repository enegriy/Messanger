-- =============================================
-- Author:		Евгений Негрий
-- Create date: 5.4.16
-- Description:	Очистка базы
-- =============================================
CREATE PROCEDURE [dbo].[sp_ClearDataBase] 
AS
BEGIN
	delete from [dbo].[User];
	delete from [dbo].[Message];
END