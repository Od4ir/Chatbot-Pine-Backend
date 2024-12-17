using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;

namespace ChatbotPineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/usuarios/nomes
        [HttpGet("nomes")]
        public IActionResult GetNomesUsuarios()
        {
            var nomes = _context.Usuarios.Select(u => u.Nome).ToList();
            return Ok(nomes);
        }
    }
}
