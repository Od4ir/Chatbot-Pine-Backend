using Microsoft.AspNetCore.Mvc;
using ChatbotPineBackend.Data;
using ChatbotPineBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;

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

        // POST: api/Mensagens
        [HttpPost]
        public async Task<IActionResult> PostMensagem([FromBody] Mensagem novaMensagem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se a conversa existe no banco
            var conversa = await _context.Conversas.FindAsync(novaMensagem.Conversa_id);
            if (conversa == null)
                return NotFound(new { mensagem = "Conversa não encontrada." });

            // Adiciona a mensagem ao banco de dados
            _context.Mensagens.Add(novaMensagem);
            await _context.SaveChangesAsync();

            // Envia a mensagem para o chatbot em localhost:5000
            using (var client = new HttpClient())
            {
                try
                {
                    var resposta = await client.PostAsJsonAsync("http://localhost:5000/mensagem", new { mensagem = novaMensagem.Texto });
                    
                    if (!resposta.IsSuccessStatusCode)
                    {
                        return StatusCode((int)resposta.StatusCode, "Erro ao enviar mensagem para o chatbot.");
                    }

                    var conteudoResposta = await resposta.Content.ReadAsStringAsync();

                    return Ok(new
                    {
                        mensagemEnviada = novaMensagem.Texto,
                        respostaChatbot = conteudoResposta
                    });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { mensagem = "Erro ao se comunicar com o chatbot.", detalhes = ex.Message });
                }
            }
        }
    }
}
