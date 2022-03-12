using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.ProductFiles
{
    public interface IProductFileService
    {
        Task AddFileForProduct(string fileName,string filePath,Guid productUid);

        Task<ProductFile> GetFiles(Guid ProductUid);
    }
}
