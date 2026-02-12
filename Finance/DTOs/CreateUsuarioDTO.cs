using System.ComponentModel.DataAnnotations;

namespace Finance.DTOs
{
    public class CreateUsuarioDTO
    {
           
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }
        
        public string Senha { get; set; }
    }
}
