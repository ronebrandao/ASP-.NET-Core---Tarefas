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

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if(Id == null)
                return NotFound();

            //It does not access EF
            //It access the service that uses the EF
            var tarefaItem = _TarefaService.GetTarefaById(Id);

            if(tarefaItem == null)
                return NotFound();

            return View(tarefaItem);

        }

        //The ActionName method will garantee that in routing, the method used will have the the name defined in it
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _TarefaService.DeletarItem(Id);

            return RedirectToAction(nameof(Index));

        }
        
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if(Id == null)
                return NotFound();
            
            var TarefaItem = _TarefaService.GetTarefaById(Id);

            if(TarefaItem == null)
                return NotFound();

            return View(TarefaItem);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,EstaCompleta,Nome,DataConclusao")] TarefaItem TarefaItem)
        {

            if(Id != TarefaItem.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                try 
                {
                    await _TarefaService.Update(TarefaItem);
                }
                catch 
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(TarefaItem);
        }
        
    }
}