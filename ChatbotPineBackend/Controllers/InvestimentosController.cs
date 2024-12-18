using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;
using ChatbotPineBackend.Models;

namespace ChatbotPineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvestimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/investimentos
        [HttpGet]
        public IActionResult GetInvestimentos()
        {
            var investimentos = _context.Investimentos.ToList();
            return Ok(investimentos);
        }

        // GET: api/investimentos/{id}
        [HttpGet("{id}")]
        public IActionResult GetInvestimentoPorId(int id)
        {
            var investimento = _context.Investimentos.FirstOrDefault(i => i.Investimento_id == id);

            if (investimento == null)
            {
                return NotFound($"Investimento com ID {id} não encontrado.");
            }

            return Ok(investimento);
        }

        // GET: api/investimentos/usuario/{usuarioId}
        [HttpGet("usuario/{usuario_id}")]
        public IActionResult GetInvestimentosPorUsuarioId(int usuario_id)
        {
            var investimentos = _context.Investimentos.Where(i => i.Usuario_id == usuario_id).ToList();

            if (investimentos == null || !investimentos.Any())
            {
                return NotFound($"Nenhum investimento encontrado para o Usuário com ID {usuario_id}.");
            }

            return Ok(investimentos);
        }
    }
}
