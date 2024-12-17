using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class ProdutoContratado
    {
        [Key]
        public int ProdutoContratadoId { get; set; } // Chave primária

        public DateTime DataContratacao { get; set; }

        // Relação: Chave estrangeira para Usuario
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relação: Chave estrangeira para ProdutoBancario
        [ForeignKey("ProdutoBancario")]
        public int ProdutoId { get; set; }
        public ProdutoBancario ProdutoBancario { get; set; }
    }
}
