using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests
{
    public class ProductInsertRequest
    {
        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        
        public string Description { get; set; }


        public decimal Cost { get; set; }

        [Required]
        public int Quantity { get; set; }


        public int Threshold { get; set; }

        [Required]
        public string UserId { get; set; }


        public int MinPurchase { get; set; }


        public int MediaId { get; set; }
    }
}