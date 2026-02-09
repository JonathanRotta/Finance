using System.ComponentModel.DataAnnotations;

namespace Finance.DTOs
{
    public class CreateFinancaRequest
    {

        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(150, ErrorMessage = "A descrição deve ter no máximo 150 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        public string Categoria { get; set; } = "Geral";
    }
}
