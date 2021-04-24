SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Juan David Layton Valenzuela>
-- Create date: <24/04/2021>
-- Description:	<Procedimiento para obtener las propiedades por owner.>
-- =============================================
CREATE PROCEDURE RealCompany.sp_getPropertysByOwner
	@IdOwner Bigint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	IdProperty,
			[Name],
			[Address],
			Price,
			CodeInternal,
			[Year]
	FROM	RealCompany.Property
	WHERE	[State] IN (1,2)
			AND IDOwner = @IdOwner;
END
GO