using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using administracionCliente_Api.Entities;
using administracionCliente_Api.Repository;
using administracionCliente_Api.Services;

namespace administracionCliente_Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private readonly IEmpresaService empresaService;

        public EmpresaController(AplicationDbContext context, IEmpresaService empresaService)
        {
            _context = context;
            this.empresaService = empresaService;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaEntity>>> GetEmpresa()
        {
            return await empresaService.GetEmpresa();
        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaEntity>> GetEmpresaEntity(int id)
        {
            var empresaEntity = await _context.Empresa.FindAsync(id);

            if (empresaEntity == null)
            {
                return NotFound();
            }

            return empresaEntity;
        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresaEntity(int id, EmpresaEntity empresaEntity)
        {
            if (id != empresaEntity.empresaNumero)
            {
                return BadRequest();
            }

            _context.Entry(empresaEntity).State = EntityState.Modified;

            try
            {
            
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaEntityExists(id))
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

        // POST: api/Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpresaEntity>> PostEmpresaEntity(EmpresaEntity empresaEntity)
        {
            _context.Empresa.Add(empresaEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresaEntity", new { id = empresaEntity.empresaNumero }, empresaEntity);
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaEntity(int id)
        {
            var empresaEntity = await _context.Empresa.FindAsync(id);
            if (empresaEntity == null)
            {
                return NotFound();
            }

            _context.Empresa.Remove(empresaEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaEntityExists(int id)
        {
            return _context.Empresa.Any(e => e.empresaNumero == id);
        }
    }
}
