using CadastroContatos.Models;

namespace CadastroContatos.Repository
{
    public interface IContatoRepository
    {
        ContatoModel Adicionar(ContatoModel contato);
    }
}
