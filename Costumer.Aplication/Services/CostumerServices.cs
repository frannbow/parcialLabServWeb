using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Costumer.Aplication.DTO;
using Costumer.Aplication.Validations;
using Costumer.Domain.Entities;
using Costumer.Domain.Repositories;

namespace Costumer.Aplication.Services
{
    public class CostumerServices : iCostumerServices
    {
        private readonly iCostumerRepository _repository;
        private readonly CostumerValidation _validations;
        private readonly IMapper _mapper;
        private readonly idValidator _idvalidator;

        public CostumerServices(iCostumerRepository repository,IMapper mapper,CostumerValidation validations, idValidator idvalidator)
        {
            _repository = repository;
            _validations = validations;
            _idvalidator = idvalidator;
            _mapper = mapper;
        }
        public async Task DeleteAsync(int id)
        {
            var validation = _idvalidator.Validate(id);
            if (!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Producto no válido: {errores}");
            }
            var costumer = await _idvalidator.BeAValidId(id);
            if (!costumer)
            {
                throw new ArgumentException($"No existe producto con el id: {id}");
            }

            await _repository.DeleteAsync(id);
        }
        public async Task<CostumerEntity> GetByIdAsync(int id)
        {
            int costumerId = id;
            var validation = _idvalidator.Validate(costumerId);
            if (!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Id no válido: {errores}");
            }
            var result = await _repository.GetAsync(costumerId);
            return result;
        }
        public async Task<List<CostumerEntityDTO>> ListAsync()
        {
            var costumers = await _repository.ListAsync();

            //var weather = await _weatherServices.GetAllWeatherInfo();    

            var results = _mapper.Map<List<CostumerEntityDTO>>(costumers);

            return results;
        }
        public async Task<CostumerEntityDTO> PostCostumers(CostumerEntityDTO costumer)
        {
            var costumerEntity = _mapper.Map<CostumerEntity>(costumer);

            var costumervalidator = _validations.Validate(costumerEntity);
            if (!costumervalidator.IsValid)
            {
                var errores = string.Join(" | ", costumervalidator.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Producto no válido: {errores}");
            }
            await _repository.AddAsync(costumerEntity);
            return costumer;
        }

        public async Task<CostumerEntity> UpdateAsync(int id, CostumerEntity costumer)
        {
            var updatedCostumer = _mapper.Map<CostumerEntity>(costumer);
            var costumerId = id;
            var costumervalidator = _validations.Validate(updatedCostumer);
            var validation = _idvalidator.Validate(costumerId);

            if (!costumervalidator.IsValid)
            {
                var errores = string.Join(" | ", costumervalidator.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Producto no válido: {errores}");
            }

            if (!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Id no válido: {errores}");
            }
            var result = await _repository.updateAsync(id, updatedCostumer);
            return result; ;
        }
    }
}
