using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class Conversa
    {
        [Key]
        public int Conversa_id { get; set; } // Chave primária

        [Required]
        public DateTime Data_inicio { get; set; }

        public DateTime? Data_fim { get; set; } // Data de término da conversa, pode ser nula

        [Required]
        public int Usuario_id { get; set; } // ID do usuário que iniciou a conversa

        // Relacionamento: Uma conversa pode ter várias mensagens
        public List<Mensagem> Mensagens { get; set; }
    }
}
