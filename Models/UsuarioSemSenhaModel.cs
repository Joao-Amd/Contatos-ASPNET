using ControladorContatos.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControladorContatos.Models
{
    public class UsuarioModelSemSenha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Usuario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do Usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do Usuario")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do Usuario")]
        public PerfilEnum? Perfil { get; set; }
    }
}
