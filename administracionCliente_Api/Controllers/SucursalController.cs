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
    [Route("/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public SucursalController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sucursal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalEntity>>> GetSucursal()
        {
            return await _context.Sucursal.ToListAsync();
        }

        // GET: api/Sucursal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalEntity>> GetSucursalEntity(int id)
        {
            var sucursalEntity = await _context.Sucursal.FindAsync(id);

            if (sucursalEntity == null)
            {
                return NotFound();
            }

            return sucursalEntity;
        }

        // PUT: api/Sucursal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursalEntity(int id, SucursalEntity sucursalEntity)
        {
            if (id != sucursalEntity.sucursalNumero)
            {
                return BadRequest();
            }

            _context.Entry(sucursalEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalEntityExists(id))
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

        // POST: api/Sucursal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SucursalEntity>> PostSucursalEntity(SucursalEntity sucursalEntity)
        {
            _context.Sucursal.Add(sucursalEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSucursalEntity", new { id = sucursalEntity.sucursalNumero }, sucursalEntity);
        }

        // DELETE: api/Sucursal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursalEntity(int id)
        {
            var sucursalEntity = await _context.Sucursal.FindAsync(id);
            if (sucursalEntity == null)
            {
                return NotFound();
            }

            _context.Sucursal.Remove(sucursalEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SucursalEntityExists(int id)
        {
            return _context.Sucursal.Any(e => e.sucursalNumero == id);
        }
    }
}
