SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Juan David Layton Valenzuela>
-- Create date: <24/04/2021>
-- Description:	<Procedimiento para obtener las ventas de las propiedades por propiedad.
-- =============================================
CREATE PROCEDURE RealCompany.sp_getPropertyTrace
	@IdPropety Bigint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	IdPropertyTrace,
			DateSale,
			[Name],
			[Value],
			Tax
	FROM	RealCompany.PropertyTrace
	WHERE	IdProperty = @IdPropety;
END
GO