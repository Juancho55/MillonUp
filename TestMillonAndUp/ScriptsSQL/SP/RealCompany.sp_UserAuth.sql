SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Juan David Layton Valenzuela>
-- Create date: <24/04/2021>
-- Description:	<Procedimiento para la autenticación del usuario para poder tener el token de acceso.>
-- =============================================
CREATE PROCEDURE RealCompany.sp_UserAuth
	@NikName nvarchar(10),
	@Password nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @PWConvert nvarchar(100) 
	
	SELECT @PWConvert = sys.fn_varbintohexsubstring(0, HashBytes('SHA1', @Password), 1, 0);

	SELECT	IdOwner,
			[Name],
			[Address],
			Photo,
			BirthDay
	FROM	RealCompany.Owner
	WHERE	[State] = 1 
			AND [NikName] = @NikName
			AND [Password] = '0x' + UPPER(@PWConvert);
END
GO
