using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using AnimalShelter.Filter;
using AnimalShelter.Wrappers;
using AnimalShelter.Services;
using AnimalShelter.Helpers;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalShelterContext _db;
        private readonly IUriService uriService;

        public AnimalsController(AnimalShelterContext context, IUriService uriService)
        {
            this._db = context;
            this.uriService = uriService;
        }

        //GET: api/Animals
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            return await _db.Animals.ToListAsync();
        }

        // Method to get paginated animals; we couldn't figure out how to connect this with the client side, but left it in for documentation of our work
        [MapToApiVersion("2.0")]
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _db.Animals
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();
            var totalRecords = await _db.Animals.CountAsync();
            // var response = await _db.Animals.ToListAsync();
            var pagedResponse = PaginationHelper.CreatePagedReponse<Animal>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedResponse);
        }

        // GET: api/Animals/5
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _db.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        // Method edited to work with get paginated animals; we couldn't figure out how to connect this with the client side, but left it in for documentation of our work
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimalV2(int id)
        {
            var animal = await _db.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(new Response<Animal>(animal));
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.AnimalId)
            {
                return BadRequest();
            }

            _db.Entry(animal).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // return NoContent();
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
        }


        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.AnimalId }, animal);
        }


        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _db.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _db.Animals.Remove(animal);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return _db.Animals.Any(e => e.AnimalId == id);
        }
    }
}
