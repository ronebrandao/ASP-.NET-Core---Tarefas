using System;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Models
{
    public class TarefaItem
    {
        // Guid é um número inteiro de 128 bits. É usado onde é necessário  um identificador único
        [Key]  
        public int Id { get; set; }
        [Display(Name="Tarefa Completa")]
        public bool EstaCompleta { get; set; }
        [Required(ErrorMessage="O nome da tarefa é obrigatório")]
        [StringLength(200)]
        public string Nome { get; set; }
        
        // "?" * Permite que um tipo valor receba um valor null
        [Display(Name="Data de Conclusão")]
        public DateTimeOffset? DataConclusao { get; set; }
        
    }
}