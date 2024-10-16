using System.ComponentModel.DataAnnotations;

namespace CadastroContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do Contato - Preenchimento Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email do Contato - Preenchimento Obrigatório")]
        [EmailAddress(ErrorMessage = "Email informado não é um e-mail valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Celular do Contato - Preenchimento Obrigatório")]
        [Phone(ErrorMessage = "O celular informado não é um celular válido")]
        public string Celular { get; set; }
    }
}
