using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.BusinessObject.DTO.ecole;
using Data.Model;
using Data.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoleMeilleurDisponnible.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcoleController : ControllerBase
    {
        public readonly IEcoleRepository _ecoleRepository;
        private readonly IMapper _mapper;


        public EcoleController(IMapper mapper, IEcoleRepository ecoleRepository)
        {
            _mapper = mapper;
            _ecoleRepository = ecoleRepository;
        }

        // GET: api/Ecole/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetEcole(long id)
        {
            Ecole ecole = await _ecoleRepository.GetById(id);

            if (ecole == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<EcoleResponseDto>(ecole);

            return Ok(res);
        }

        // POST: api/Ecole
        [HttpPost]
        public async Task<IActionResult> CreateEcole([FromBody] EcoleCreateDto ecoleCreateDto)
        {
            if (ecoleCreateDto.name == null)
            {
                return BadRequest();
            }

            Ecole ecole = Ecole.From(ecoleCreateDto);
            await _ecoleRepository.CreateEntity(ecole);
            var res = await _ecoleRepository.SaveAsync();

            if (!res)
            {
                return BadRequest();
            }

            return Created("ecole/me", ecole);
        }

        // PUT: api/Ecole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEcole([FromBody] long id, EcoleCreateDto ecoleCreateDto)
        {
            if (ecoleCreateDto.name == null)
            {
                return BadRequest();
            }

            Ecole ecole = await _ecoleRepository.GetById(id);
            if (ecole == null)
            {
                return NotFound();
            }

            ecole.Name = ecoleCreateDto.name;

            var res = await _ecoleRepository.SaveAsync();
            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Ecole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Ecole ecole = await _ecoleRepository.GetById(id);
            if (ecole == null)
            {
                return NotFound();
            }

            _ecoleRepository.DeleteEntity(ecole);

            var res = await _ecoleRepository.SaveAsync();
            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
