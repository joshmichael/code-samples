

ALTER PROCEDURE [dbo].[Product_Insert]
	@CompanyId int,
	@Name nvarchar(150),
	@Category nvarchar(150),
	@Description nvarchar(150),
	@Cost money = null,
	@Quantity int,
	@Threshold int = null,
	@UserId nvarchar(128) ,
	@MinPurchase int = null,
	@mediaId int,
	@Id int OUTPUT


AS

BEGIN

INSERT INTO [dbo].[Products]
	([CompanyId]
	,[Name]
	,[Category]
	,[Description]
	,[Cost]
	,[Quantity]
	,[Threshold]
	,[DateCreated]
	,[UserId]
	,[MinPurchase]
	,[mediaId])

VALUES
	(@CompanyId
	,@Name
	,@Category
	,@Description
	,@Cost
	,@Quantity
	,@Threshold
	,GETDATE()
	,@UserId
	,@MinPurchase
	,@mediaId)

SET @Id = SCOPE_IDENTITY()


END

/*------------TEST CODE ---------------------

DECLARE  @CompanyId int = 111
		,@Name nvarchar(150) = 'Steel Beems'
		,@Category nvarchar(150) = 'STEEL'
		,@Description nvarchar(150) = '8 feet long by 10 inches square'
		,@Cost money = 275.00
		,@Quantity int = 100
		,@Threshold int = 20
		,@UserId nvarchar(128) = '1zxcn-sh456j-f3433jjj'
		,@MinPurchase int = 20
		,@mediaId int
		,@Id int	

EXECUTE [dbo].[Product_Insert]
		 @CompanyId
		,@Name
		,@Category
		,@Description
		,@Cost
		,@Quantity
		,@Threshold
		,@UserId
		,@MinPurchase
		,@mediaId
		,@Id

SELECT	 [Id]
		,[CompanyId]
		,[Name]
		,[Category]
		,[Description]
		,[Cost]
		,[Quantity]
		,[Threshold]
		,[DateCreated]
		,[UserId]
		,[mediaId]
		,[MinPurchase]

FROM [dbo].[Products]

*/
