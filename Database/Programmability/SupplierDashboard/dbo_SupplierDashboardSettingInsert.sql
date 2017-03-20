

ALTER PROCEDURE [dbo].[SupplierDashboardSettingInsert]
	@UserId nvarchar (150),
	@CompanyId int,
	@AddressId int,
	@CategoryId int,
	@CategoryName nvarchar (150),
	@RangeNotification int,
	@TierOneCategoryId int,
	@TierTwoCategoryId int,
	@TierThreeCategoryId int,
	@TierFourCategoryId int,
	@Id int OUTPUT	
AS

BEGIN

INSERT INTO [dbo].[SupplierDashboardSettings]
	([UserId]
	,[CompanyId]
	,[AddressId]
	,[CategoryId]
	,[CategoryName]
	,[RangeNotification]	
	,[TierOneCategoryId]
	,[TierTwoCategoryId]
	,[TierThreeCategoryId]
	,[TierFourCategoryId]
	,[DateCreated])

VALUES
	(@UserId
	,@CompanyId
	,@AddressId
	,@CategoryId
	,@CategoryName
	,@RangeNotification
	,@TierOneCategoryId 
	,@TierTwoCategoryId
	,@TierThreeCategoryId
	,@TierFourCategoryId
	,GETDATE())

SET @Id = SCOPE_IDENTITY()

END

/*------------TEST CODE ---------------------

DECLARE @UserId nvarchar (150) = '0413cc60-ed35-4fc7-a03c-eb2bc0bce46a'  	
	,@CompanyId int = 41
	,@AddressId int = 123
	,@CategoryId int = 103
	,@CategoryName nvarchar (150) = '00 01 01 - Project Title Page'
	,@RangeNotification int = 500
	,@TierOneCategoryId int = 1
	,@TierTwoCategoryId int = 1
	,@TierThreeCategoryId int = 1
	,@TierFourCategoryId int = 1
	,@Id int	 

EXECUTE [dbo].[SupplierDashboardSettingInsert]
		 @UserId
		,@CompanyId
		,@AddressId
		,@CategoryId
		,@CategoryName
		,@RangeNotification
		,@TierOneCategoryId
		,@TierTwoCategoryId
		,@TierThreeCategoryId
		,@TierFourCategoryId
		,@Id
	
SELECT	 [Id]
		,[UserId]
		,[CompanyId]
		,[AddressId]
		,[CategoryId]
		,[CategoryName]
		,[RangeNotification]
		,[DateCreated]
		,[TierOneCategoryId]
		,[TierTwoCategoryId]
		,[TierThreeCategoryId]
		,[TierFourCategoryId]

FROM [dbo].[SupplierDashboardSettings]

*/
