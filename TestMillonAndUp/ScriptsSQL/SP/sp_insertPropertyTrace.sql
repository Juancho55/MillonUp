SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Juan David Layton Valenzuela>
-- Create date: <24/04/2021>
-- Description:	<Procedimiento para insertar las ventas de las propiedades por propiedad.
-- =============================================
CREATE PROCEDURE RealCompany.sp_insertPropertyTrace
	@IdPropety Bigint,
	@DateSale DateTime,
	@Name nvarchar,
	@Value decimal(22,2),
	@Tax decimal(18,2)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY 
		BEGIN TRANSACTION INSERTTRACE
			INSERT INTO RealCompany.PropertyTrace
			(
				DateSale,
				[Name],
				[Value],
				Tax,
				IdProperty
			)
			VALUES
			(
				@DateSale,
				@Name,
				@Value,
				@Tax,
				@IdPropety
			);
		COMMIT TRANSACTION INSERTTRACE
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRANSACTION INSERTTRACE;
	END CATCH
END
GO