using AutoMapper;
using Parcial.API.DTO;
using Parcial.Aplication.DTOs;

namespace Parcial.API.Profiles
{
    public class ProductControllerProfile : Profile
    {
        public ProductControllerProfile() 
        {
            CreateMap<CreateProductRequest, ProductDTO>();
        }
    }
}
