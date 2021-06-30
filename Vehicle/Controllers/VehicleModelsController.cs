using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;
using Vehicle.Service.Common.Interface;
using Vehicle.WebAPI.Dtos;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelsController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        public IMapper _mapper { get; }
        public VehicleModelsController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult> GetAllModelsAsync(int makeId)
        {
            var modelItems = await _vehicleModelService.GetAllModelsServiceAsync(makeId);
            return Ok(_mapper.Map<IEnumerable<ModelReadDto>>(modelItems));
        }


        [HttpGet("{id}", Name = "GetModelById")]
        public async Task<ActionResult<ModelReadDto>> GetModelByIdAsync(int id)
        {

            var modelItem = await _vehicleModelService.GetModelByIdServiceAsync(id);
            if (modelItem != null)
            {
                return Ok(_mapper.Map<ModelReadDto>(modelItem));
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<ModelReadDto>> CreateModelAsync(ModelCreateDto modelCreateDto)
        {
            var modelModel = _mapper.Map<VehicleModel>(modelCreateDto);
            await _vehicleModelService.CreateModelServiceAsync(modelModel);

            var modelReadDto = _mapper.Map<ModelReadDto>(modelModel);

            return CreatedAtRoute(nameof(GetModelByIdAsync), new { modelReadDto.Id }, modelReadDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateModelAsync(int id, ModelUpdateDto modelUpdateDto)
        {
            try
            {
                var modelFromRepo = _mapper.Map<ModelUpdateDto, VehicleModel>(modelUpdateDto);
                var numberOfChanges = await _vehicleModelService.UpdateModelServiceAsync(modelFromRepo);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModelAsync(int id)
        {
            var modelIdFromRepo = _vehicleModelService.GetModelByIdServiceAsync(id);
            if (modelIdFromRepo == null)
            {
                return NotFound();
            }
            await _vehicleModelService.DeleteModelServiceAsync(id);
            return NoContent();
        }
    }
}