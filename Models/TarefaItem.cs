using System;

namespace Tarefas.Models
{
    public class TarefaItem
    {
        // Guid é um número inteiro de 128 bits. É usado onde é necessário  um identificador único
        public Guid Id { get; set; }
        public bool EstaCompleta { get; set; }
        public string Nome { get; set; }
        
        // "?" * Permite que um tipo valor receba um valor null
        public DateTimeOffset? DataConclusao { get; set; }
        
    }
}