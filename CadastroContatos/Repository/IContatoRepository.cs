using CadastroContatos.Models;

namespace CadastroContatos.Repository
{
    public interface IContatoRepository
    {
        List<ContatoModel> ListarTodos();

        ContatoModel Adicionar(ContatoModel contato);
    }
}
