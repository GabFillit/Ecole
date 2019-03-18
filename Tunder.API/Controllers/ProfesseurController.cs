using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Model.Repository;
using Data.Model;
using Data.BusinessObject.DTO.ecole;

namespace EcoleMeilleurDisponnible.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseurController : ControllerBase
    {
        public IProfesseurRepository _professeurRepository;
        public IEcoleRepository _ecoleRepository;
        private readonly IMapper _mapper;

        public ProfesseurController(IMapper mapper, IProfesseurRepository professeurRepository, IEcoleRepository ecoleRepository)
        {
            _mapper = mapper;
            _professeurRepository = professeurRepository;
        }

        // GET: api/Professeur
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Professeur/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetProfesseur(long id)
        {
            Professeur professeur = await _professeurRepository.GetById(id);

            if (professeur == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<ProfesseurResponseDto>(professeur);

            return Ok(res);
        }

        // POST: api/Professeur
        [HttpPost]
        public async Task<IActionResult> CreateProfesseur([FromBody] long ecoleId, ProfesseurCreateDto professeurCreateDto)
        {
            if (professeurCreateDto.name == null)
            {
                return BadRequest();
            }

            Ecole ecole = await _ecoleRepository.GetById(ecoleId);
            if (ecole == null)
            {
                return NotFound();
            }

            Professeur professeur = Professeur.From(professeurCreateDto);
            professeur.Ecole = ecole;

            await _professeurRepository.CreateEntity(professeur);
            var res = await _ecoleRepository.SaveAsync();

            if (!res)
            {
                return BadRequest();
            }

            return Created("professeur/me", professeur);
        }

        // PUT: api/Professeur/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfesseur([FromBody] long id, ProfesseurCreateDto professeurCreateDto)
        {
            if (professeurCreateDto.name == null)
            {
                return BadRequest();
            }

            Professeur professeur = await _professeurRepository.GetById(id);
            if (professeur == null)
            {
                return NotFound();
            }

            professeur.Name = professeurCreateDto.name;

            var res = await _professeurRepository.SaveAsync();
            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Professeur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Professeur professeur = await _professeurRepository.GetById(id);
            if (professeur == null)
            {
                return NotFound();
            }

            _professeurRepository.DeleteEntity(professeur);

            var res = await _professeurRepository.SaveAsync();
            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
