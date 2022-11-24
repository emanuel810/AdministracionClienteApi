using administracionCliente_Api.Entities;
using administracionCliente_Api.Repository;
using administracionCliente_Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace administracionCliente_Api.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly AplicationDbContext _context;

        public EmpresaService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<EmpresaEntity>>> GetEmpresa()
        {
            return await _context.Empresa.ToListAsync();
        }
    }
}
