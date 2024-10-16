using CadastroContatos.Models;
using CadastroContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado =  _contatoRepository.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso!";

                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro ao excluir o contato";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao excluir o contato! Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao cadastrar o contato! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao alterar o contato! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
