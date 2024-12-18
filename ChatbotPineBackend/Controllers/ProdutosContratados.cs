using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;
using ChatbotPineBackend.Models;

namespace ChatbotPineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosContratadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutosContratadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/produtoscontratados/usuario/{usuarioId}
        [HttpGet("usuario/{usuario_id}")]
        public IActionResult GetProdutosContratadosPorUsuario(int usuario_id)
        {
            var produtosContratados = _context.ProdutosContratados
                .Where(pc => pc.Usuario_id == usuario_id)
                .Select(pc => pc.ProdutoBancario)
                .ToList();

            if (produtosContratados == null || !produtosContratados.Any())
            {
                return NotFound($"Nenhum produto contratado encontrado para o usuário com ID {usuario_id}.");
            }

            return Ok(produtosContratados);
        }

        // GET: api/produtoscontratados/nao-contratados/usuario/{usuarioId}
        [HttpGet("nao-contratados/usuario/{usuario_id}")]
        public IActionResult GetProdutosNaoContratadosPorUsuario(int usuario_id)
        {
            var produtosContratadosIds = _context.ProdutosContratados
                .Where(pc => pc.Usuario_id == usuario_id)
                .Select(pc => pc.Produto_id)
                .ToList();

            var produtosNaoContratados = _context.ProdutosBancarios
                .Where(p => !produtosContratadosIds.Contains(p.Produto_id))
                .ToList();

            if (produtosNaoContratados == null || !produtosNaoContratados.Any())
            {
                return NotFound($"Todos os produtos já foram contratados pelo usuário com ID {usuario_id}.");
            }

            return Ok(produtosNaoContratados);
        }
    }
}
