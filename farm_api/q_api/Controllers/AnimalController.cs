﻿using h_data.DataAccessInterfaces;
using h_data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace q_api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalDA _animalDA;

        public AnimalController(IAnimalDA animalDA)
        {
            _animalDA = animalDA;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Animal animal)
        {
            try
            {
                await _animalDA.Create(animal);
                return Ok(new
                {
                    Message = "Animal created."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{animalId}")]
        public async Task<IActionResult> Update(Animal animal, int animalId)
        {
            try
            {
                await _animalDA.Update(animal, animalId);
                return Ok(new
                {
                    Message = "Animal updated."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{animalId}")]
        public async Task<IActionResult> Delete(int animalId)
        {
            try
            {
                await _animalDA.Delete(animalId);
                return Ok(new
                {
                    Message = "Animal deleted."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> Filter(int? animalId, string? name, string? sex, string? status)
        {
            try
            {
                var data = await _animalDA.Filter(animalId, name, sex, status);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
