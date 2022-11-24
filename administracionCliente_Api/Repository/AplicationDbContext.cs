using administracionCliente_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace administracionCliente_Api.Repository
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PersonaEntity> Persona { get; set; }
        public DbSet<EmpresaEntity> Empresa { get; set; }
        public DbSet<SucursalEntity> Sucursal { get; set; }
    }
}
