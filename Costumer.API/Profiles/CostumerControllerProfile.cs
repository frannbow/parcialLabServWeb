using Costumer.API.DTOs;
using Costumer.Aplication.DTO;

namespace Costumer.API.Profiles
{
    public class CostumerControllerProfile : AutoMapper.Profile
    {
        public CostumerControllerProfile()
        {
            CreateMap<CostumerEntityRequestDTO, CostumerEntityDTO>();
        }
    }
}
