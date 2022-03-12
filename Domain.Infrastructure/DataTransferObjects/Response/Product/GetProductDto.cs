using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.DataTransferObjects.Response.Product
{
    public class GetProductDto
    {
        public Guid Uid { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public List<GetFileDto> Files { get; set; }

    }


    public class GetFileDto
    {
        public Guid Uid { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
