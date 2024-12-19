using Microsoft.EntityFrameworkCore;
using ChatbotPineBackend.Models;

namespace ChatbotPineBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets representam tabelas no banco de dados
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<ProdutoBancario> ProdutosBancarios { get; set; }
        public DbSet<ProdutoContratado> ProdutosContratados { get; set; }
        public DbSet<Conversa> Conversas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
    }
}
 