using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadoService _service;

        public EmpleadosController(EmpleadoService service)
        {
            _service = service;
        }

        [HttpGet("arbol")]
        public ActionResult<EmpleadoNodo> GetArbol()
        {
            return Ok(_service.ConstruirArbol());
        }

        [HttpGet]
        public ActionResult<List<Empleado>> GetAll()
        {
            return Ok(_service.ObtenerTodos());
        }

        [HttpPost]
        public IActionResult Post(Empleado emp)
        {
            _service.Insertar(emp);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Empleado emp)
        {
            _service.Actualizar(emp);
            return Ok();
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            _service.Eliminar(codigo);
            return Ok();
        }
    }
}
