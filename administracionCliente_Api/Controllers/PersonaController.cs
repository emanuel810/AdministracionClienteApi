using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using administracionCliente_Api.Entities;
using administracionCliente_Api.Repository;

namespace administracionCliente_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public PersonaController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaEntity>>> GetPersona()
        {
            return await _context.Persona.ToListAsync();
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaEntity>> GetPersonaEntity(int id)
        {
            var personaEntity = await _context.Persona.FindAsync(id);

            if (personaEntity == null)
            {
                return NotFound();
            }

            return personaEntity;
        }

        // PUT: api/Persona/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaEntity(int id, PersonaEntity personaEntity)
        {
            if (id != personaEntity.personaNumero)
            {
                return BadRequest();
            }

            _context.Entry(personaEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Persona
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonaEntity>> PostPersonaEntity(PersonaEntity personaEntity)
        {
            _context.Persona.Add(personaEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonaEntity", new { id = personaEntity.personaNumero }, personaEntity);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaEntity(int id)
        {
            var personaEntity = await _context.Persona.FindAsync(id);
            if (personaEntity == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(personaEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaEntityExists(int id)
        {
            return _context.Persona.Any(e => e.personaNumero == id);
        }
    }
}
