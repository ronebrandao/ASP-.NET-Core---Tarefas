using System.Threading.Tasks;
using System.Collections.Generic;
using Tarefas.Data;
using Tarefas.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tarefas.Services
{
    public class TarefaItemService : ITarefaItemService
    {
        private readonly ApplicationDbContext _context;
        //Dependency Injections
        public TarefaItemService(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task<IEnumerable<TarefaItem>> GetItemAsync()
        {
            var tarefas = await _context.Tarefas 
                        .Where(t => t.EstaCompleta == false)
                        .ToArrayAsync();
            
            return tarefas;
        }

        public async Task<bool> AdicionarItem(TarefaItem NovoItem)
        {
            var tarefa = new TarefaItem
            {
                EstaCompleta = false,
                Nome = NovoItem.Nome,
                DataConclusao = NovoItem.DataConclusao
            };

            //Add task to database context
            _context.Tarefas.Add(tarefa);
            //Persist task to database
            var resultado = await _context.SaveChangesAsync();

            return resultado == 1;;

        }

    }
}