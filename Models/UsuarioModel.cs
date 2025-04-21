using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecideAi.Models
{
    [Table("USUARIO")]
    public class UsuarioModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O número do endereço é obrigatório")]
        public string NumeroEndereco { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string CEP { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Senha { get; set; }

    }
}
