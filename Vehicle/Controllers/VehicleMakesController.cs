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
    public class VehicleMakesController : Controller
    {
        private readonly IMakeRepository _vehicleMakeRepository;

        public IMapper _mapper { get; }

        public VehicleMakesController(IMakeRepository vehicleMakeRepository, IMapper mapper)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MakeReadDto>>> GetAllMakes()
        {
            var makeItems = await _vehicleMakeRepository.GetAllMakes();
            return Ok(_mapper.Map<IEnumerable<MakeReadDto>>(makeItems));
        }

        [HttpGet("{id}", Name = "GetMakeById")]
        public async Task<ActionResult<MakeReadDto>> GetMakeById(int? id)
        {

            var makeItem = await _vehicleMakeRepository.GetMakeById(id);
            if (makeItem != null)
            {
                return Ok(_mapper.Map<MakeReadDto>(makeItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<MakeReadDto>> CreateMake(MakeCreateDto makeCreateDto)
        {
            var makeModel = _mapper.Map<VehicleMake>(makeCreateDto);
            await _vehicleMakeRepository.CreateMake(makeModel);

            var makeReadDto = _mapper.Map<MakeReadDto>(makeModel);

            return CreatedAtRoute(nameof(GetMakeById), new { Id = makeReadDto.Id }, makeReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMake(int id, MakeUpdateDto makeUpdateDto)
        {
            try
            {
                var makeFromRepo = _mapper.Map<MakeUpdateDto, VehicleMake>(makeUpdateDto);
                var numberOfChanges = await _vehicleMakeRepository.UpdateMake(makeFromRepo);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMake(int? id)
        {
            var makeIdFromRepo = _vehicleMakeRepository.GetMakeById(id);
            if (makeIdFromRepo == null)
            {
                return NotFound();
            }
            await _vehicleMakeRepository.DeleteMake(id);

            return NoContent();
        }
    }
}

