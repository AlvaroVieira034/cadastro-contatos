using CadastroContatos.Models;
using CadastroContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository) 
        {
            _contatoRepository = contatoRepository;

        } 

        public IActionResult Index()
        {
           List<ContatoModel> contatos =  _contatoRepository.ListarTodos();

           return View(contatos);
        }


        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");

        }
    }
}
