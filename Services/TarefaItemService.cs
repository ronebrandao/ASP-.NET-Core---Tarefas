using System.Threading.Tasks;
using System.Collections.Generic;
using Tarefas.Data;
using Tarefas.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Tarefas.Services
{
    public class TarefaItemService : ITarefaItemService
    {
        private readonly ApplicationDbContext _context;
        //Dependency Injection
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

        public async Task<bool> DeletarItem(int? Id)
        {
            TarefaItem tarefa = _context.Tarefas.Find(Id);
            _context.Tarefas.Remove(tarefa);

            //Will return the numbers of rows affected, if only one item have been changed
            //The task should be successeful
            var resultado = await _context.SaveChangesAsync();

            return resultado == 1;

        }

        public TarefaItem GetTarefaById(int? Id)
        {
            return _context.Tarefas.Find(Id);
        }

        public async Task Update(TarefaItem item)
        {
            if(item == null)
                throw new ArgumentException(nameof(item));

            _context.Tarefas.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}