

ALTER PROC [dbo].[Product_Update]
	     	 @CompanyId int = 0
		,@Name nvarchar(150)
		,@Category nvarchar(150) 
		,@Description nvarchar(150)
		,@Cost money 
		,@Quantity int 
		,@Threshold int 
		,@UserId nvarchar(128)
		,@MinPurchase int
		,@mediaId int
		,@Id int

as

BEGIN

	UPDATE [dbo].[Products]
	   SET [CompanyId] = @CompanyId
		  ,[Name] = @Name
		  ,[Category] = @Category
		  ,[Description] = @Description
		  ,[Cost] = @Cost
		  ,[Quantity] = @Quantity
		  ,[Threshold] = @Threshold
		  ,[UserId] = @UserId
		  ,[MinPurchase] = @MinPurchase
		  ,[mediaId] = @mediaId
	 WHERE Id = @Id

END

/* ================= TEST CODE ==================

DECLARE @Id int = 3;

DECLARE	@CompanyId int = 456
		,@Name nvarchar(150) = 'sfgasdfasfdf'
		,@Category = 'anything'
		,@Description nvarchar(150) = 'nnhgfngfnhg'
		,@Cost money = 750
		,@Quantity int = 1500
		,@Threshold int = 300
		,@DateCreated datetime = getdate()
		,@UserId nvarchar(128) = 'dfggf-e5ret-67uj567j'
		,@MinPurchase int = 150
		,@mediaId int = 65

		SELECT *
		FROM dbo.Products
		Where Id = @Id

EXECUTE [dbo].[Product_Update]
		 @CompanyId
		,@Name
		,@Category
		,@Description 
		,@Cost
		,@Quantity
		,@Threshold
		,@DateCreated
		,@UserId
		,@MinPurchase
		,@mediaId
		,@Id
		
		SELECT *
		FROM dbo.Products
		Where Id = @Id

		
*/