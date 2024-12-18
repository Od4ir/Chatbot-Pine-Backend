using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;
using ChatbotPineBackend.Models;

namespace ChatbotPineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/transacoes
        [HttpGet]
        public IActionResult GetTransacoes()
        {
            var transacoes = _context.Transacoes.ToList();
            return Ok(transacoes);
        }

        // GET: api/transacoes/conta/{numeroConta}
        [HttpGet("conta/{numero_conta}")]
        public IActionResult GetTransacoesPorConta(int numero_conta)
        {
            var transacoes = _context.Transacoes.Where(t => t.Numero_conta == numero_conta).ToList();

            if (transacoes == null || !transacoes.Any())
            {
                return NotFound($"Nenhuma transação encontrada para a conta {numero_conta}.");
            }

            return Ok(transacoes);
        }

    }
}
