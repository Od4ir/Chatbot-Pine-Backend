using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class Investimento
    {
        [Key]
        public int InvestimentoId { get; set; } // Chave primária

        [Required]
        public string Tipo { get; set; } // Ex: CDB, LCI, Ações

        [Required]
        public decimal ValorAplicado { get; set; }

        [Required]
        public decimal Rendimento { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataVencimento { get; set; }

        // Relação: Chave estrangeira para Usuario
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
