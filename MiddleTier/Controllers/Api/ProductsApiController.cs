using Microsoft.Practices.Unity;
using Sabio.Web.Domain;
using Sabio.Web.Models.Requests;
using Sabio.Web.Models.Responses;
using Sabio.Web.Services;
using Sabio.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/products")]
    public class ProductsApiController : ApiController
    {

        //....// =========================== DEPENDENCY INJECTION BEGIN ===========================================

        [Dependency]
        public IProductService _ProductService { get; set; }


        [Dependency]
        public IAdminService _AdminService { get; set; }

        //....// =========================== DEPENDENCY INJECTION END =============================================





        //....// ===================================================================================
        [Route(), HttpPost]
        [Authorize]
        public HttpResponseMessage ProductInsert(ProductInsertRequest model) // - Model binding
        {

            if (!ModelState.IsValid) // - Validate data received
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            string userId = UserService.GetCurrentUserId(); // - Get current logged in user

            UserProfileDomain userProfile = _AdminService.ProfileGetByUserId(userId); // - Get/populate userProfile

            model.UserId = userId; // - Populate model with userId
            model.CompanyId = userProfile.CompanyId; // - Populate model with currently logged in users CompanyId

            ProductService ProductInsert = new ProductService(); // - Instantiate object ProductInsert

            int productId = _ProductService.ProductInsert(model); // - Call ProductInsert method, set result to variable product Id

            ItemResponse<int> response = new ItemResponse<int>(); // - Instantiate response model

            response.Item = productId; // - Populate response model

            return Request.CreateResponse(HttpStatusCode.OK, response); // - Return response model obect

        }





        //....// ===================================================================================
        [Route(), HttpGet]
        [Authorize]
        public HttpResponseMessage GetAllProducts()
        {

            List<ProductDomain> productArray = _ProductService.GetAllProducts(); // - Call GetAllProducts method, populate object list productArray

            ItemsResponse<ProductDomain> response = new ItemsResponse<ProductDomain>(); // - Instantiate response model

            response.Items = productArray; // - Populate response model

            return Request.CreateResponse(HttpStatusCode.OK, response); // - Return response model obect

        }





        //....// ===================================================================================
        [Route("{id:int}"), HttpGet]
        [Authorize]
        public HttpResponseMessage GetProductById(ProductGetRequest model) // - Model binding
        {

            if (!ModelState.IsValid) // - Validate data received
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ProductDomain product = _ProductService.GetProductById(model); // - Call method GetProductById, populate object product

            ItemResponse<ProductDomain> response = new ItemResponse<ProductDomain>(); // - Instantiate response model

            response.Item = product; // - Populate response model

            return Request.CreateResponse(HttpStatusCode.OK, response); // - Return response model
        }





        //....// ===================================================================================
        [Route("companyid")HttpGet]
        public HttpResponseMessage GetProductsByCompanyId(ProductGetRequest model) // - Model binding
        {

            if (!ModelState.IsValid) // - Validate data received
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            string userId = UserService.GetCurrentUserId(); // - Get current user logged in 

            UserProfileDomain userProfile = _AdminService.ProfileGetByUserId(userId); // - Populate currently logged in userProfile 

            model.UserId = userId; // - Populate model with userId
            model.CompanyId = userProfile.CompanyId; // - Populate model with currently logged in users CompanyId

            List<ProductDomain> products = _ProductService.GetProductsByCompanyId(model); // - Populate products list

            ItemsResponse<ProductDomain> response = new ItemsResponse<ProductDomain>(); // - Instantiate response model

            response.Items = products; // - Populate response model

            return Request.CreateResponse(HttpStatusCode.OK, response); // - Return populated response model
        }





        //....// ===================================================================================
        [Route("{id:int}")HttpPut]
        [Authorize]
        public HttpResponseMessage ProductEdit(ProductUpdateRequest model) // - Model binding
        {

            if(!ModelState.IsValid) // - Validate data received
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            bool isSuccessful = _ProductService.UpdateProduct(model); // - Call UpdateProduct method & populate isSuccessful with response

            ItemResponse<bool> response = new ItemResponse<bool>();  // - Instantiate response model

            response.Item = isSuccessful; // - Populate response model

            return Request.CreateResponse(HttpStatusCode.OK, response); // - Return populated response model
        }





        //....// ===================================================================================
        [Route("{id:int}"), HttpDelete]
        [Authorize]
        public HttpResponseMessage ProductDelete(ProductDeleteRequest model) // - Model binding
        {

            if(!ModelState.IsValid) // - Validate data received
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }                       
            
            bool isSuccessfull = _ProductService.DeleteProduct(model); // - Call DeleteProduct method & populate isSuccessful with response

            ItemResponse<bool> response = new ItemResponse<bool>(); // - Instantiate response model

            response.Item = isSuccessfull; // - Populate response model

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
