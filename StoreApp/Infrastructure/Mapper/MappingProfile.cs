using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos;
using Entities.Dtos.CategoryDtos;
using Entities.Dtos.IdentityDtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

            CreateMap<CategoryDtoForInsertion, Category>();

            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }
    }
}