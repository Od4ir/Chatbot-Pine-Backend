using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotPineBackend.Models
{
    public class Mensagem
    {
        [Key]
        public int Mensagem_id { get; set; } // Chave primária

        [Required]
        [StringLength(1000)] // Limite de caracteres para a mensagem
        public string Texto { get; set; }

        [Required]
        public DateTime Data_hora { get; set; }

        [Required]
        public string Remetente { get; set; } // True = Usuário, False = Modelo/Chatbot

        // Chave estrangeira para Conversa
        [ForeignKey("Conversa")]
        public int Conversa_id { get; set; }
    }
}
