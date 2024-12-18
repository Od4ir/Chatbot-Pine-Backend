using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class ProdutoContratado
    {
        [Key]
        public int ProdutoContratado_id { get; set; } // Chave primária

        public DateTime DataContratacao { get; set; }

        // Relação: Chave estrangeira para Usuario
        [ForeignKey("Usuario")]
        public int Usuario_id { get; set; }
        public Usuario Usuario { get; set; }

        // Relação: Chave estrangeira para ProdutoBancario
        [ForeignKey("ProdutoBancario")]
        public int Produto_id { get; set; }
        public ProdutoBancario ProdutoBancario { get; set; }
    }
}
