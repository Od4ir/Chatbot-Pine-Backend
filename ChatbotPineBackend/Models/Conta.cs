using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class Conta
    {
        [Key]
        public int NumeroConta { get; set; } // Chave primária

        [Required]
        public decimal Saldo { get; set; }

        [Required]
        public decimal Limite { get; set; }

        public string Extrato { get; set; }

        // Relação: Chave estrangeira para Usuario
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relação: Uma conta pode ter várias transações
        public List<Transacao> Transacoes { get; set; }
    }
}
