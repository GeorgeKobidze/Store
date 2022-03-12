using AutoMapper;
using Domain.Infrastructure.DataTransferObjects.Request.Product;
using Domain.Infrastructure.DataTransferObjects.Response.Product;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.AutoMapperProfile.ProductMapperProfile
{
    public class ProductAutoMapperProfile : Profile
    {

        public ProductAutoMapperProfile()
        {
            CreateMap<AddProductDto,Product>()
             .ForMember(c => c.LastModifiedDateTime, op => op.Ignore())
             .ForMember(c => c.CreatedDateTime, op => op.Ignore())
             .ForMember(c => c.Deleted, op => op.Ignore())
             .ForMember(c => c.ProductCategories, op => op.Ignore())
             .ForMember(c => c.ProductFiles, op => op.Ignore())
             .ForSourceMember(c => c.ProductCategories, op => op.DoNotValidate());

            CreateMap<Product, GetAllProductDto>()
             .ForSourceMember(c => c.Deleted, op => op.DoNotValidate())
             .ForSourceMember(c => c.LastModifiedDateTime, op => op.DoNotValidate())
             .ForSourceMember(c => c.CreatedDateTime, op => op.DoNotValidate())
             .ForSourceMember(c => c.ProductCategories, op => op.DoNotValidate())
             .ForSourceMember(c => c.ProductFiles, op => op.DoNotValidate());

            CreateMap<Product, GetProductDto>()
             .ForSourceMember(c => c.Deleted, op => op.DoNotValidate())
             .ForSourceMember(c => c.LastModifiedDateTime, op => op.DoNotValidate())
             .ForSourceMember(c => c.CreatedDateTime, op => op.DoNotValidate())
             .ForSourceMember(c => c.ProductCategories, op => op.DoNotValidate())
             .ForSourceMember(c => c.ProductFiles, op => op.DoNotValidate());


            CreateMap<ProductFile, GetFileDto>()
           .ForSourceMember(c => c.Deleted, op => op.DoNotValidate())
           .ForSourceMember(c => c.LastModifiedDateTime, op => op.DoNotValidate())
           .ForSourceMember(c => c.ProductUid, op => op.DoNotValidate())
           .ForSourceMember(c => c.Product, op => op.DoNotValidate())
           .ForSourceMember(c => c.CreatedDateTime, op => op.DoNotValidate());

        }
    }
}
