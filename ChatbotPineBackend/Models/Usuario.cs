using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatbotPineBackend.Models
{
    public class Usuario
    {
        [Key]
        public int Usuario_id { get; set; } // Chave primária
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        public int Idade { get; set; }

        public string Genero { get; set; }

        // Relação: Um usuário pode ter várias contas
        public List<Conta> Contas { get; set; }

        // Relação: Um usuário pode ter vários investimentos
        public List<Investimento> Investimentos { get; set; }

        // Relação: Um usuário pode ter vários produtos contratados
        public List<ProdutoContratado> ProdutosContratados { get; set; }
    }
}
