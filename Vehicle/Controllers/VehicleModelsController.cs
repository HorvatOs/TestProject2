using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;
using Vehicle.WebAPI.Dtos;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelsController : Controller
    {
        private readonly IModelRepository _vehicleModelRepository;

        public IMapper _mapper { get; }

        public VehicleModelsController(IModelRepository vehicleModelRepository, IMapper mapper)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllModels(int makeId)
        {
            var modelItems = await _vehicleModelRepository.GetAllModels(makeId);
            return Ok(_mapper.Map<IEnumerable<ModelReadDto>>(modelItems));
        }

        [HttpGet("{id}", Name = "GetModelById")]
        public ActionResult<ModelReadDto> GetModelById(int id)
        {

            var modelItem = _vehicleModelRepository.GetModelById(id);
            if (modelItem != null)
            {
                return Ok(_mapper.Map<ModelReadDto>(modelItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ModelReadDto>> CreateModel(ModelCreateDto modelCreateDto)
        {
            var modelModel = _mapper.Map<VehicleModel>(modelCreateDto);
            await _vehicleModelRepository.CreateModel(modelModel);

            var modelReadDto = _mapper.Map<ModelReadDto>(modelModel);

            return CreatedAtRoute(nameof(GetModelById), new { modelReadDto.Id }, modelReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateModel(int id, ModelUpdateDto modelUpdateDto)
        {
            try
            {
                var modelFromRepo = _mapper.Map<ModelUpdateDto, VehicleModel>(modelUpdateDto);
                var numberOfChanges = await _vehicleModelRepository.UpdateModel(modelFromRepo);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModel(int? id)
        {
            var modelIdFromRepo = _vehicleModelRepository.GetModelById(id);
            if (modelIdFromRepo == null)
            {
                return NotFound();
            }
            await _vehicleModelRepository.DeleteModel(id);
            return NoContent();
        }
    }
}