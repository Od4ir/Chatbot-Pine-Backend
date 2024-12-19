using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;
using ChatbotPineBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatbotPineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConversasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Conversas/{id}
        [HttpGet("{conversa_id}")]
        public async Task<IActionResult> GetConversa(int conversa_id)
        {
            var conversa = await _context.Conversas
                .Include(c => c.Mensagens)
                .FirstOrDefaultAsync(c => c.Conversa_id == conversa_id);

            if (conversa == null)
                return NotFound(new { mensagem = "Conversa não encontrada." });

            return Ok(conversa);
        }

        // POST: api/Conversas
        [HttpPost]
        public async Task<IActionResult> PostConversa([FromBody] Conversa novaConversa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Conversas.Add(novaConversa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostConversa), new { id = novaConversa.Conversa_id }, novaConversa);
        }
    }
}
