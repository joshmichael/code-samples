using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests
{
    public class ProductGetRequest
    {
        public int ProductId { get; set; }

        public int CompanyId { get; set; }

        public string UserId { get; set; }

    }
}