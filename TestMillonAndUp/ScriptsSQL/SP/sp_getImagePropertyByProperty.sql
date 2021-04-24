SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Juan David Layton Valenzuela>
-- Create date: <24/04/2021>
-- Description:	<Procedimiento para obtener las imagnes de las propiedades por propiedad.>
-- =============================================
CREATE PROCEDURE RealCompany.sp_getImagePropertyByProperty
	@IdPropety Bigint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	IdPropertyImage,
			[file]
	FROM	RealCompany.PropertyImage
	WHERE	[Enabled] = 1
			AND IdProperty = @IdPropety;
END
GO