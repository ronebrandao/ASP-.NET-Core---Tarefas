using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Models;

namespace Tarefas.Services
{
    public interface ITarefaItemService
    {
        // Task > has > List (IEnumerable) > has > task items
          Task<IEnumerable<TarefaItem>> GetItemAsync();

          Task<bool> AdicionarItem(TarefaItem NovoItem);
            
          Task<bool> DeletarItem(int? Id);

          TarefaItem GetTarefaById(int? Id); 

          Task Update(TarefaItem Item);
          
    }
}