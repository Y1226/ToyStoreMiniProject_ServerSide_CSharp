using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using Entities_DTO.Repository;

namespace Entities_DTO.Mapping
{
    public class AutoMapped : Profile
    {
        public AutoMapped()
        {
            CreateMap<ProductDTO, ProductTbl>();
            CreateMap<ProductTbl, ProductDTO>();

            CreateMap<CategoryDTO, CategoryTbl>();
            CreateMap<CategoryTbl, CategoryDTO>();

            CreateMap<SalesDTO, SalesTbl>();
            CreateMap<SalesTbl, SalesDTO>();

            CreateMap<SaleDetailsDTO, SaleDetailsTbl>();
            CreateMap<SaleDetailsTbl, SaleDetailsDTO>();

            CreateMap<UserDTO, UserTbl>();
            CreateMap<UserTbl, UserDTO>();
        }
    }
}
