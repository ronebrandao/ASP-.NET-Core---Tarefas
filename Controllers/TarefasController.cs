using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tarefas.Services;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    public class TarefasController : Controller
    {
        ITarefaItemService _TarefaService;
        //Dependency Injections
        public TarefasController(ITarefaItemService TarefaService)
        {
            _TarefaService = TarefaService;
        }

        //Tasks list
        public async Task<IActionResult> Index()
        {
            //Get data and return to view
            var Tarefas = await _TarefaService.GetItemAsync();

            var Model = new TarefaViewModel();
            {
                Model.TarefaItens = Tarefas;
            }

            return View(Model);
        }

        //Used to consult the user
        [HttpGet]
        public IActionResult AdicionarItemTarefa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItemTarefa([Bind("Id,EstaCompleta,Nome,DataConclusao")]TarefaItem Tarefa)
        {

            if(ModelState.IsValid)
            {
                await _TarefaService.AdicionarItem(Tarefa);
                return RedirectToAction(nameof(Index));
            }
            
            return View(Tarefa);
        }
        
    }
}