using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Parcial.Aplication.DTOs;
using Parcial.Domain.Entities;


namespace Parcial.Aplication.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<ProductDTO,Product>().ReverseMap();
        }
    }
}
