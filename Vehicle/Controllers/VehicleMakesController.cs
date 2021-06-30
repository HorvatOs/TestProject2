using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Common.Paging;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Interface;
using Vehicle.Service.Common.Interface;
//using Vehicle.Service.Service;
using Vehicle.WebAPI.Dtos;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakesController : Controller
    {
        private readonly IVehicleMakeService _vehicleMakeService;

        public IMapper _mapper { get; }

        public VehicleMakesController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MakeReadDto>>> GetAllMakesAsync(PagingParameters pagingParameters)
        {
            var makeItems = await _vehicleMakeService.GetAllMakesServiceAsync(pagingParameters);
            return Ok(_mapper.Map<IEnumerable<MakeReadDto>>(makeItems));
        }

        [HttpGet("{id}", Name = "GetMakeById")]
        public async Task<ActionResult<MakeReadDto>> GetMakeByIdAsync(int id)
        {

            var makeItem = await _vehicleMakeService.GetMakeByIdServiceAsync(id);
            if (makeItem != null)
            {
                return Ok(_mapper.Map<MakeReadDto>(makeItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<MakeReadDto>> CreateMakeAsync(MakeCreateDto makeCreateDto)
        {
            var makeModel = _mapper.Map<VehicleMake>(makeCreateDto);
            await _vehicleMakeService.CreateMakeServiceAsync(makeModel);

            var makeReadDto = _mapper.Map<MakeReadDto>(makeModel);

            return CreatedAtRoute(nameof(GetMakeByIdAsync), new { Id = makeReadDto.Id }, makeReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMakeAsync(int id, MakeUpdateDto makeUpdateDto)
        {
            try
            {
                var makeFromRepo = _mapper.Map<MakeUpdateDto, VehicleMake>(makeUpdateDto);
                var numberOfChanges = await _vehicleMakeService.UpdateMakeServiceAsync(makeFromRepo);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMakeAsync(int id)
        {
            var makeIdFromRepo = _vehicleMakeService.GetMakeByIdServiceAsync(id);
            if (makeIdFromRepo == null)
            {
                return NotFound();
            }
            await _vehicleMakeService.DeleteMakeServiceAsync(id);

            return NoContent();
        }
    }
}

