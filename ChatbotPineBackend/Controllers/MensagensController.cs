using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;
using ChatbotPineBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatbotPineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MensagensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MensagensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Mensagens/PorUsuario/{userId}
        [HttpGet("PorUsuario/{user_id}")]
        public async Task<IActionResult> GetMensagensByUserId(int user_id)
        {
            var mensagens = await _context.Mensagens
                .Include(m => m.Conversa)
                .Where(m => m.Conversa.Usuario_id == user_id)
                .OrderBy(m => m.Data_hora)
                .ToListAsync();

            if (mensagens == null || mensagens.Count == 0)
                return NotFound(new { mensagem = "Nenhuma mensagem encontrada para o usuário informado." });

            return Ok(mensagens);
        }

        // POST: api/Mensagens
        [HttpPost]
        public async Task<IActionResult> PostMensagem([FromBody] Mensagem novaMensagem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var conversa = await _context.Conversas.FindAsync(novaMensagem.Conversa_id);
            if (conversa == null)
                return NotFound(new { mensagem = "Conversa não encontrada." });

            _context.Mensagens.Add(novaMensagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostMensagem), new { id = novaMensagem.Mensagem_id }, novaMensagem);
        }
    }
}
