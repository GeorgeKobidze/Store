using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.DataTransferObjects.Request.Product
{
    public class AddProductDto
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal Price { get; set; } 
        public int Quantity { get; set; }
        public ProductCategoriesDto ProductCategories { get; set; }
    }

    public class ProductCategoriesDto
    {
        public Guid CategoryUid { get; set; }
        public Guid SubCategoryUid { get; set; }
    }

}
