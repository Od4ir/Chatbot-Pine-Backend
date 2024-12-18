using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class Transacao
    {
        [Key]
        public int Transacao_id { get; set; } // Chave primária

        [Required]
        public string Tipo { get; set; } // Ex: Depósito, Saque, Pagamento

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data_hora { get; set; }

        public string Descricao { get; set; }

        // Relação: Chave estrangeira para Conta
        [ForeignKey("Conta")]
        public int Numero_conta { get; set; }
        public Conta Conta { get; set; }
    }
}
