using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;
using ChatbotPineBackend.Models;

namespace ChatbotPineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/contas
        [HttpGet]
        public IActionResult GetContas()
        {
            var contas = _context.Contas.ToList();
            return Ok(contas);
        }

        // GET: api/contas/{id}
        [HttpGet("{id}")]
        public IActionResult GetContaPorId(int id)
        {
            var conta = _context.Contas.FirstOrDefault(c => c.Numero_conta == id);

            if (conta == null)
            {
                return NotFound($"Conta com Número {id} não encontrada.");
            }

            return Ok(conta);
        }

        // GET: api/contas/usuario/{usuarioId}
        [HttpGet("usuario/{usuario_id}")]
        public IActionResult GetContasPorUsuarioId(int usuario_id)
        {
            var contas = _context.Contas.Where(c => c.Usuario_id == usuario_id).ToList();

            if (contas == null || !contas.Any())
            {
                return NotFound($"Nenhuma conta encontrada para o Usuário com ID {usuario_id}.");
            }

            return Ok(contas);
        }
    }
}
