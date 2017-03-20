using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Sabio.Web.Domain
{
    public class ProductDomain
    {
        public int ProductId { get; set; }

        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public int Quantity { get; set; }

        public int Threshold { get; set; }

        public string UserId { get; set; }

        public int MinPurchase { get; set; }

        public int MediaId { get; set; }

        public int CategoryId { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string Address1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public decimal distance_in_mi { get; set; }


    }
}