using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial.Infrastructure.Repositories;
using Parcial.Domain.Repositories;
using Parcial.Aplication.Services;
using Parcial.Domain.Entities;
using Parcial.Aplication.DTOs;
using Parcial.API.DTO;
using AutoMapper;
using MediatR;
using Parcial.Aplication.UseCases.Product.Queries;
using Parcial.Aplication.UseCases.Product.Queries.ListProducts;
using Parcial.Aplication.UseCases.Product.Commands.CreateProduct;
using Parcial.Aplication.UseCases.Product.Queries.GetProductByID;

namespace PracticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly iProductServices _Services;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ProductoController(iProductServices productservices, IMapper mapper, ISender mediator)
    
        {
            _Services = productservices;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
          //var products = await _Services.ListAsync();

          // return Ok(products);

            var listproductquery = new ListProductsQuery();
            var result = await _mediator.Send<ListProductsResponse>(listproductquery);
            return Ok(result.Products);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getproductById = new GetProductByIDQuery(id);
                var result = await _mediator.Send<GetProductByIdResponse>(getproductById);
                result.Products = _mapper.Map<ProductDTO>(result.Products);
                return Ok(result.Products);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
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
                var createproductCommand = new CreateProductCommand
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    Description = productDTO.Description
                };
                var result = await _mediator.Send<CreateProductResponse>(createproductCommand);
                //await _Services.PostProduct(productDTO);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateById(int id, [FromBody] UpdatedProductDTO product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var productId = id;
                var updatedProduct = _mapper.Map<Product>(product);
                
                var result = await _Services.UpdateAsync(id, updatedProduct);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
