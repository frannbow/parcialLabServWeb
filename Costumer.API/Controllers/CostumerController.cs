using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Costumer.Infrastructure.Repositories;
using Costumer.Domain.Repositories;

using Costumer.Domain.Entities;

using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Hosting.Server;
using Costumer.Aplication.Services;
using Costumer.API.DTOs;
using Costumer.Aplication.UseCases.Costumer.Queries.ListCostumer;
using Costumer.Aplication.UseCases.Costumer.Queries.GetCostumerByID;
using Costumer.Aplication.UseCases.Costumer.Commands.CreateCostumer;
using Costumer.API.Controllers;
using Costumer.Aplication.DTO;
using Costumer.Aplication.UseCases.Costumer.Commands.DeleteCostumer;

namespace CostumerControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {

        private readonly iCostumerServices _Services;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public CostumerController(iCostumerServices costumerservices, IMapper mapper, ISender mediator)

        {
            _Services = costumerservices;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            //var products = await _Services.ListAsync();

            // return Ok(products);

            var listcostumerquery = new ListCostumerQuery();
            var result = await _mediator.Send<ListCostumerResponse>(listcostumerquery);
            return Ok(result.Costumers);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getcostumertById = new GetCostumerByIDQuery(id);
                var result = await _mediator.Send<GetCostumerByIdResponse>(getcostumertById);
                result.Costumers = _mapper.Map<CostumerEntityDTO>(result.Costumers);
                return Ok(result.Costumers);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CostumerEntityRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var costumerDTO = _mapper.Map<Costumer.Aplication.DTO.CostumerEntityDTO>(request);
                var createproductCommand = new CreateCostumerCommand
                {
                    Name = costumerDTO.Name,
                    LastName = costumerDTO.LastName,
                    Email = costumerDTO.Email
                };
                var result = await _mediator.Send<CreateCostumerResponse>(createproductCommand);
                //await _Services.PostProduct(productDTO);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateById(int id, [FromBody] UpdatedProductDTO costumer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var costumerId = id;
                var updatedCostumer = _mapper.Map<CostumerEntity>(costumer);

                var result = await _Services.UpdateAsync(id, updatedCostumer);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteCostumerCommand = new DeleteCostumerCommand(id);
                var result = await _mediator.Send(deleteCostumerCommand);
                return Ok("Cliente eliminado");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
