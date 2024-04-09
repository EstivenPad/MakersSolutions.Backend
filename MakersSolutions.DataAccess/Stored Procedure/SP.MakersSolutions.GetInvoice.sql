GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].SP_GetInvoice
(
	@ID INT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		I.*,
		C.Name,
		C.Lastname,
		C.Address,
		C.Phone
	FROM [dbo].Invoices AS I
	INNER JOIN [dbo].Customers AS C
	ON I.CustomerId = C.Id
	WHERE I.Id = @ID;
END
GO
