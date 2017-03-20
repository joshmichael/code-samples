
ALTER PROC [dbo].[SupplierDashboard_GetSettingsByUserId]
	@UserId nvarchar(150)

AS

BEGIN

SELECT dbo.SupplierDashboardSettings.Id
      ,dbo.SupplierDashboardSettings.UserId
      ,dbo.SupplierDashboardSettings.CompanyId
      ,dbo.SupplierDashboardSettings.AddressId
      ,dbo.Addresses.Address1
      ,dbo.SupplierDashboardSettings.CategoryId
      ,dbo.SupplierDashboardSettings.CategoryName
      ,dbo.SupplierDashboardSettings.RangeNotification
      ,dbo.SupplierDashboardSettings.TierOneCategoryId
      ,dbo.SupplierDashboardSettings.TierTwoCategoryId
      ,dbo.SupplierDashboardSettings.TierThreeCategoryId
      ,dbo.SupplierDashboardSettings.TierFourCategoryId

  FROM dbo.Addresses INNER JOIN
                  dbo.SupplierDashboardSettings ON dbo.Addresses.Id = dbo.SupplierDashboardSettings.AddressId

  WHERE UserId = @UserId AND
		NOT dbo.SupplierDashboardSettings.AddressId IS NULL

END

/* ===================== TEST CODE ==============================

	DECLARE @UserId nvarchar (150) = '0413cc60-ed35-4fc7-a03c-eb2bc0bce46a';
	EXECUTE dbo.SupplierDashboard_GetSettingsByUserId
			@UserId

*/