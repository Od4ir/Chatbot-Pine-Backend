using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;
using ChatbotPineBackend.Models;

namespace ChatbotPineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosBancariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutosBancariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/produtosbancarios
        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = _context.ProdutosBancarios.ToList();
            return Ok(produtos);
        }

        // GET: api/produtosbancarios/{id}
        [HttpGet("{id}")]
        public IActionResult GetProdutoPorId(int id)
        {
            var produto = _context.ProdutosBancarios.FirstOrDefault(p => p.Produto_id == id);

            if (produto == null)
            {
                return NotFound($"Produto Bancário com ID {id} não encontrado.");
            }

            return Ok(produto);
        }
    }
}
