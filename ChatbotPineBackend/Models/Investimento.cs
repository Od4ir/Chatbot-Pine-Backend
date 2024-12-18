using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class Investimento
    {
        [Key]
        public int Investimento_id { get; set; } // Chave primária

        [Required]
        public string Tipo { get; set; } // Ex: CDB, LCI, Ações

        [Required]
        public decimal Valor_aplicado { get; set; }

        [Required]
        public decimal Rendimento { get; set; }

        public DateTime Data_inicio { get; set; }

        public DateTime Data_vencimento { get; set; }

        // Relação: Chave estrangeira para Usuario
        [ForeignKey("Usuario")]
        public int Usuario_id { get; set; }
        public Usuario Usuario { get; set; }
    }
}
