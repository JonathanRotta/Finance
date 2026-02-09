using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Models
{
    [Table("financas")]
    public class Financas
    {
        [Key] // Chave primária
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descricao { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Categoria { get; set; } = "Geral";

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}

