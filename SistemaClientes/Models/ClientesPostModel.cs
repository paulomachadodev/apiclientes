using System.ComponentModel.DataAnnotations;

namespace SistemaClientes.Models
{
    public class ClientesPostModel
    {
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe 11 dígitos numéricos.")]
        [Required(ErrorMessage = "Por favor, informe o Cpf do cliente.")]
        public string Cpf { get; set; }

        [MaxLength(11, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o telefone do cliente.")]
        public string Telefone { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o e-mail do cliente.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente.")]
        public DateTime DataNascimento { get; set; }
    }
}
