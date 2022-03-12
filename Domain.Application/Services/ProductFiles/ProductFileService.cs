using Domain.Infrastructure.Services.UnitOfWork;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services.ProductFiles
{
    public class ProductFileService : IProductFileService
    {
        private readonly IUnitOfWork<ProductFile> _iunitofWork;

        public ProductFileService(IUnitOfWork<ProductFile> iunitofWork)
        {
            _iunitofWork = iunitofWork;
        }

        public async Task AddFileForProduct(string fileName, string filePath, Guid productUid)
        {
            var _productFile = new ProductFile()
            {
                FileName = fileName,
                FilePath = filePath,
                ProductUid = productUid
            };
            await _iunitofWork.Repository.Add(_productFile);
            await _iunitofWork.CommitAsync();
        }

        public async Task<ProductFile> GetFiles(Guid ProductUid)
        {
            return await _iunitofWork.Repository.Where(e => e.ProductUid == ProductUid).FirstOrDefaultAsync();
        }
    }
}
