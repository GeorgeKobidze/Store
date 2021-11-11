using AutoMapper;
using Domain.Infrastructure.DataTransferObjects.Response.Category;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.AutoMapperProfile.CategoryMapperProfile
{
    public class CategoryAutoMapperProfile : Profile
    {
        public CategoryAutoMapperProfile()
        {
            CreateMap<Category, CategoriesListDto>()
                .ForSourceMember(c => c.ProductCategories, op => op.DoNotValidate())                
                .ForSourceMember(c => c.CreatedDateTime, op => op.DoNotValidate())
                .ForSourceMember(c => c.LastModifiedDateTime, op => op.DoNotValidate())
                .ForSourceMember(c => c.Deleted, op => op.DoNotValidate())
                .ForMember(c => c.SubCatgeoriesList, op => op.MapFrom(op => op.SubCategories));


            CreateMap<SubCategory, SubCatgeoriesListDto>()
                .ForSourceMember(c => c.ProductCategories, op => op.DoNotValidate())
                .ForSourceMember(c => c.CreatedDateTime, op => op.DoNotValidate())
                .ForSourceMember(c => c.LastModifiedDateTime, op => op.DoNotValidate())
                .ForSourceMember(c => c.Deleted, op => op.DoNotValidate())
                .ForSourceMember(c => c.Category, op => op.DoNotValidate());

        }
    }
}
