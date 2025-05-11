using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial.Infrastructure.Repositories;
using Parcial.Domain.Repositories;
using Parcial.Aplication.Services;
using Parcial.Domain.Entities;
using Parcial.Aplication.DTOs;
using Parcial.API.DTO;
using AutoMapper;

namespace PracticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly iProductServices _Services;
        private readonly IMapper _mapper;
        public ProductoController(iProductServices productservices, IMapper mapper)
    
        {
            _Services = productservices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
          var products = await _Services.ListAsync();

           return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProductRequest request)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var productDTO = _mapper.Map<ProductDTO>(request);
                //var productDTO = new ProductDTO()
                //{
                //    Name = request.Name,
                //    Price = request.Price,
                //    Description = request.Description
                //};
                await _Services.PostProduct(productDTO);
                return Ok(productDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
