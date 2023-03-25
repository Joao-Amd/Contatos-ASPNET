using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ControladorContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-Mail do Contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do Contato")]
        [Phone(ErrorMessage = "O Celular informado não é valido!")]
        public string Celular { get; set; }
    }
}
