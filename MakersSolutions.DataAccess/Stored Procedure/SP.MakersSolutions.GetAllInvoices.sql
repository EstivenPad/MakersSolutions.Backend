USE [MakersSolutionsDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllInvoices]    Script Date: 4/6/2024 10:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllInvoices]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].Invoices;
END
