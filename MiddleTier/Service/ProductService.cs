using Sabio.Web.Services;
using System.Data.SqlClient;
using System.Data;
using Sabio.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sabio.Data;
using Sabio.Web.Controllers;
using Sabio.Web.Domain;
using Sabio.Web.Services.Interfaces;

namespace Sabio.Web.Services
{
    public class ProductService : BaseService, IProductService // - Inheriting abstract class BaseService
    {

        //....// ==============================================================================================
        public int ProductInsert(ProductInsertRequest model) // - Model binding
        {
            int id = 0; // - Register variable id to memory

            try
            {
                DataProvider.ExecuteNonQuery(GetConnection, "dbo.Product_Insert" // - Mapping data to stored proc
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@CompanyId", model.CompanyId);
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Category", model.Category);
                    paramCollection.AddWithValue("@Description", model.Description);
                    paramCollection.AddWithValue("@Cost", model.Cost);
                    paramCollection.AddWithValue("@Quantity", model.Quantity);
                    paramCollection.AddWithValue("@Threshold", model.Threshold);
                    paramCollection.AddWithValue("@UserId", model.UserId);
                    paramCollection.AddWithValue("@MinPurchase", model.MinPurchase);
                    paramCollection.AddWithValue("@mediaId", model.MediaId);

                    SqlParameter p = new SqlParameter("@id", System.Data.SqlDbType.Int); 
                    p.Direction = System.Data.ParameterDirection.Output;

                    paramCollection.Add(p);
                },

                 returnParameters: delegate (SqlParameterCollection param) // - Prepare property Id
                 {
                     int.TryParse(param["@Id"].Value.ToString(), out id);

                 });
            }

            catch(Exception ex) // - Throw standard exception if data doesn't map properly
            {
                throw ex;
            }
            
            return id; // - SQL response id
        }





        //....// ==============================================================================================
        public List<ProductDomain> GetAllProducts()
        {
            List<ProductDomain> productList = null; // - Register productList variable to memory

            try
            {
                DataProvider.ExecuteCmd(GetConnection, "dbo.Products_GetAll" // - Mapping data from stored proc
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                { }
            , map: delegate (IDataReader reader, short set)
            {
                ProductDomain SingleProduct = new ProductDomain(); // - Instantiating object SingleProduct

                int startingIndex = 0;

                SingleProduct.ProductId = reader.GetSafeInt32(startingIndex++);
                SingleProduct.CompanyId = reader.GetSafeInt32(startingIndex++);
                SingleProduct.Name = reader.GetSafeString(startingIndex++);
                SingleProduct.Category = reader.GetSafeString(startingIndex++);
                SingleProduct.Description = reader.GetSafeString(startingIndex++);
                SingleProduct.Cost = reader.GetSafeDecimal(startingIndex++);
                SingleProduct.Quantity = reader.GetSafeInt32(startingIndex++);
                SingleProduct.Threshold = reader.GetSafeInt32(startingIndex++);
                SingleProduct.UserId = reader.GetSafeString(startingIndex++);
                SingleProduct.MinPurchase = reader.GetSafeInt32(startingIndex++);
                SingleProduct.MediaId = reader.GetSafeInt32(startingIndex++);

                if (productList == null) // - Check if object productList is undefined
                {
                    productList = new List<ProductDomain>(); // - Define object productList
                }

                productList.Add(SingleProduct); // - Populate object productList with object SingleProduct
            });
            }

            catch (Exception ex) // - Throw standard exception if data doesn't map properly
            {
                throw ex;
            }
            
            return productList; // - Return the popluated object productList
        }





        //....// ==============================================================================================
        public ProductDomain GetProductById(ProductGetRequest model) // - Model binding
        {
            ProductDomain SingleProduct = null; // Register SingleProduct variable to memory

            try
            {
                DataProvider.ExecuteCmd(GetConnection, "dbo.Products_GetById" // - Mapping data to-from stored proc
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", model.ProductId);
                }, map: delegate (IDataReader reader, short set)
                {

                    SingleProduct = new ProductDomain(); // - Define object SingleProduct 
                    int startingIndex = 0;

                    SingleProduct.ProductId = reader.GetSafeInt32(startingIndex++);
                    SingleProduct.CompanyId = reader.GetSafeInt32(startingIndex++);
                    SingleProduct.Name = reader.GetSafeString(startingIndex++);
                    SingleProduct.Category = reader.GetSafeString(startingIndex++);
                    SingleProduct.Description = reader.GetSafeString(startingIndex++);
                    SingleProduct.Cost = reader.GetSafeDecimal(startingIndex++);
                    SingleProduct.Quantity = reader.GetSafeInt32(startingIndex++);
                    SingleProduct.Threshold = reader.GetSafeInt32(startingIndex++);
                    SingleProduct.UserId = reader.GetSafeString(startingIndex++);
                    SingleProduct.MinPurchase = reader.GetSafeInt32(startingIndex++);
                    SingleProduct.MediaId = reader.GetSafeInt32(startingIndex++);
                });
            }
            catch (Exception ex) // - Throw standard exception if data doesn't map properly
            {
                throw ex;
            }

            return SingleProduct; // - Return object SingleProduct
        }





        //....// ==============================================================================================
        public List<ProductDomain> GetProductsByCompanyId(ProductGetRequest model) // - Model binding
        {
            List<ProductDomain> productList = null; // - Register productList to memory

            try
            {
                DataProvider.ExecuteCmd(GetConnection, "dbo.Products_GetByCompanyId" // - Mapping data to-from stored proc
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@CompanyId", model.CompanyId);
                }, map: delegate (IDataReader reader, short set)
             {
                 ProductDomain SingleProduct = new ProductDomain(); // - Instantiating object SingleProduct

                 int startingIndex = 0;

                 SingleProduct.ProductId = reader.GetSafeInt32(startingIndex++);
                 SingleProduct.CompanyId = reader.GetSafeInt32(startingIndex++);
                 SingleProduct.Name = reader.GetSafeString(startingIndex++);
                 SingleProduct.Category = reader.GetSafeString(startingIndex++);
                 SingleProduct.Description = reader.GetSafeString(startingIndex++);
                 SingleProduct.Cost = reader.GetSafeDecimal(startingIndex++);
                 SingleProduct.Quantity = reader.GetSafeInt32(startingIndex++);
                 SingleProduct.Threshold = reader.GetSafeInt32(startingIndex++);
                 SingleProduct.UserId = reader.GetSafeString(startingIndex++);
                 SingleProduct.MinPurchase = reader.GetSafeInt32(startingIndex++);
                 SingleProduct.MediaId = reader.GetSafeInt32(startingIndex++);

                 if (productList == null) // - Check if object productList is undefined
                 {
                     productList = new List<ProductDomain>(); // - Define object productList
                 }

                 productList.Add(SingleProduct); // - Populate productList with object SingleProduct

             });
            }

            catch (Exception ex) // - Throw standard exception if data doesn't map properly
            {
                throw ex;
            }

                return productList; // - Return populated object productList
            
        }





        //....// ==============================================================================================
        public bool UpdateProduct(ProductUpdateRequest model) // - Model binding
        {
            bool success = false; // Registering success variable

            try
            {
                DataProvider.ExecuteNonQuery(GetConnection, "dbo.Product_Update" // - Mapping data to-from stored proc
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", model.ProductId);
                    paramCollection.AddWithValue("@CompanyId", model.CompanyId);
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Category", model.Category);
                    paramCollection.AddWithValue("@Description", model.Description);
                    paramCollection.AddWithValue("@Cost", model.Cost);
                    paramCollection.AddWithValue("@Quantity", model.Quantity);
                    paramCollection.AddWithValue("@Threshold", model.Threshold);
                    paramCollection.AddWithValue("@UserId", model.UserId);
                    paramCollection.AddWithValue("@MinPurchase", model.MinPurchase);
                    paramCollection.AddWithValue("@mediaId", model.MediaId);

                    success = true; // - If SQL data maps, set success variable to true
                });
            }
            catch (Exception ex) // - Throw standard exception if update fails
            {
                throw ex;
            }

            return success; // - Return true if successfull
        }





        //....// ==============================================================================================
        public bool DeleteProduct(ProductDeleteRequest model) // - Model binding
        {
            bool success = false; // Registering success variable

            try
            {
                DataProvider.ExecuteNonQuery(GetConnection, "dbo.Product_DeleteById"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", model.ProductId);

                    success = true; // - If SQL data maps, set success variable to true
                });
            }
            catch (Exception ex) // - Throw standard exception if delete fails
            {
                throw ex;
            }

            return success; // - Return true if successfull
        }
    }
}