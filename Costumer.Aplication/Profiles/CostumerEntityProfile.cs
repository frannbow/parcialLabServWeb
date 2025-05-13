using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Costumer.Aplication.DTO;
using Costumer.Domain.Entities;

namespace Costumer.Aplication.Profiles
{
    public class CostumerEntityProfile : Profile
    {
        public CostumerEntityProfile()
        {
            CreateMap<CostumerEntityDTO, CostumerEntity>().ReverseMap();

        }
    }
}
