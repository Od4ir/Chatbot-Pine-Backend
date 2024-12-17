using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class Transacao
    {
        [Key]
        public int TransacaoId { get; set; } // Chave primária

        [Required]
        public string Tipo { get; set; } // Ex: Depósito, Saque, Pagamento

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        public string Descricao { get; set; }

        // Relação: Chave estrangeira para Conta
        [ForeignKey("Conta")]
        public int NumeroConta { get; set; }
        public Conta Conta { get; set; }
    }
}
