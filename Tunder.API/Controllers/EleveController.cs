using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.BusinessObject.DTO.eleve;
using Data.Model;
using Data.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoleMeilleurDisponnible.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleveController : ControllerBase
    {
        private IEleveRepository _eleveRepository;
        public IEcoleRepository _ecoleRepository;
        private readonly IMapper _mapper;

        public EleveController(IMapper mapper, IEleveRepository eleveRepository, IEcoleRepository ecoleRepository)
        {
            _eleveRepository = eleveRepository;
            _ecoleRepository = ecoleRepository;
            _mapper = mapper;
        }

        // GET: api/Eleve
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Eleve/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetEleve(int id)
        {
            Eleve eleve = await _eleveRepository.GetById(id);

            if (eleve == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<EleveResponseDto>(eleve);

            return Ok(res);
        }

        // POST: api/Eleve
        [HttpPost]
        public async Task<IActionResult> CreateEleve([FromBody] long ecoleId, EleveCreateDto eleveCreateDto)
        {
            if (eleveCreateDto.name == null)
            {
                return BadRequest();
            }

            Ecole ecole = await _ecoleRepository.GetById(ecoleId);
            if (ecole == null)
            {
                return NotFound();
            }

            Eleve eleve = eleve.From(eleveCreateDto);
            eleve.Ecole = ecole;

            await _eleveRepository.CreateEntity(eleve);
            var res = await _ecoleRepository.SaveAsync();

            if (!res)
            {
                return BadRequest();
            }

            return Created("professeur/me", eleve);
        }

        // PUT: api/Eleve/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEleve([FromBody] long id, EleveCreateDto eleveCreateDto)
        {
            if (eleveCreateDto.name == null)
            {
                return BadRequest();
            }

            Eleve eleve = await _eleveRepository.GetById(id);
            if (eleve == null)
            {
                return NotFound();
            }

            eleve.Name = eleveCreateDto.name;

            var res = await _eleveRepository.SaveAsync();
            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Eleve/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Eleve eleve = await _eleveRepository.GetById(id);
            if (eleve == null)
            {
                return NotFound();
            }

            _eleveRepository.DeleteEntity(eleve);

            var res = await _eleveRepository.SaveAsync();
            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
