using ControladorContatos.Models;
using ControladorContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControladorContatos.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatosController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public ActionResult Index()
        {
            List<ContatoModel> contato = _contatoRepositorio.BuscarTodos();

            return View(contato);
        }
        

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult Apagar(int id)
        {
           
            try
            {
                bool apagdo = _contatoRepositorio.Apagar(id);
                if (apagdo)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops não foi possivel apagar o contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops não foi possivel apagar o contato, datalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid) // verificar se é valido minha model
                {
                    _contatoRepositorio.Adcionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel cadastrar o contato, tente novamente, datalhe do erro: {erro.Message}";
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
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel alterar o contato, tente novamente, datalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}
