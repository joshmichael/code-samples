using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sabio.Web.Models.Requests;
using Sabio.Web.Domain;

namespace Sabio.Web.Services.Interfaces
{
    public interface IProductService
    {
        int ProductInsert(ProductInsertRequest model);

        List<ProductDomain> GetAllProducts();

        ProductDomain GetProductById(ProductGetRequest model);

        List<ProductDomain> GetProductsByCompanyId(ProductGetRequest model);

        bool UpdateProduct(ProductUpdateRequest model);

        bool DeleteProduct(ProductDeleteRequest model);
    }
}