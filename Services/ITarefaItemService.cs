using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Models;

namespace Tarefas.Services
{
    public interface ITarefaItemService
    {
        // Task > contém > Lista (IEnumerable) > contém > os itens da tarefa
          Task<IEnumerable<TarefaItem>> GetItemAsync();
          
    }
}