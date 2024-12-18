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
        // GET: api/usuarios/{id}/nome
        [HttpGet("{id}/nome")]
        public IActionResult GetNomeUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Usuario_id == id);

            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }

            return Ok(usuario.Nome);
        }

        // GET: api/usuarios/{id}/email
        [HttpGet("{id}/email")]
        public IActionResult GetEmailUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Usuario_id == id);

            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }

            return Ok(usuario.Email);
        }

        // GET: api/usuarios/{id}/telefone
        [HttpGet("{id}/telefone")]
        public IActionResult GetTelefoneUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Usuario_id == id);

            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }

            return Ok(usuario.Telefone);
        }

        // GET: api/usuarios/{id}/idade
        [HttpGet("{id}/idade")]
        public IActionResult GetIdadeUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Usuario_id == id);

            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }

            return Ok(usuario.Idade);
        }

        // GET: api/usuarios/{id}/genero
        [HttpGet("{id}/genero")]
        public IActionResult GetGeneroUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Usuario_id == id);

            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }

            return Ok(usuario.Genero);
        }

        // GET: api/usuarios/email/{email}/id
        [HttpGet("email/{email}/id")]
        public IActionResult GetIdUsuarioPorEmail(string email)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound($"Usuário com email {email} não encontrado.");
            }

            return Ok(usuario.Usuario_id);
        }

    }
}
