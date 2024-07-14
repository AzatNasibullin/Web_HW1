﻿using AutoMapper;
using Web_HW1.Dto;
using Web_HW1.Models;

namespace WebAppGeek.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
            CreateMap<Storage, StorageDto>().ReverseMap();
        }
    }
}