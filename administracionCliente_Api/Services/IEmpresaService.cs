
using administracionCliente_Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace administracionCliente_Api.Services
{
    public interface IEmpresaService
    {
        public Task<ActionResult<IEnumerable<EmpresaEntity>>> GetEmpresa();




    }
}
