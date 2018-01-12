using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tarefas.Services;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    public class TarefasController : Controller
    {
        ITarefaItemService _TarefaService;
        //Injeção de dependência
        public TarefasController(ITarefaItemService TarefaService)
        {
            _TarefaService = TarefaService;
        }

        //Lista de tarefas
        public async Task<IActionResult> Index()
        {
            //Obter os dados e retornar
            var Tarefas = await _TarefaService.GetItemAsync();

            var model = new TarefaViewModel();
            {
                model.TarefaItens = Tarefas;
            }

            return View(model);
        }
        
    }
}