using System.ComponentModel.DataAnnotations;

namespace ChatbotPineBackend.Models
{
    public class ProdutoBancario
    {
        [Key]
        public int ProdutoId { get; set; } // Chave primária

        [Required]
        public string Tipo { get; set; } // Ex: CDB, LCI, Cartão Consignado

        public string Descricao { get; set; }

        public decimal TaxaJuros { get; set; }

        public string Requisitos { get; set; }
    }
}
