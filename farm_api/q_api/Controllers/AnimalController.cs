using h_data.DataAccessInterfaces;
using h_data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace q_api.Controllers
{
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
