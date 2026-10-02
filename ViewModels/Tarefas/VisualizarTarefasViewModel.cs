using System.ComponentModel.DataAnnotations;

namespace HouseholdTasks.ViewModels.Tarefas
{
    public class VisualizarTarefasViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Status")]
        public StatusViewModel Status { get; set; }

        public ResponsavelViewModel Responsavel { get; set; }
        
        [Display(Name = "Responsável")]
        public string ResponsavelNome { get; set; }

        public VisualizarTarefasViewModel(
            Guid id,
            string titulo,
            string responsavelNome,
            StatusViewModel status)
        {
            Id = id;
            Titulo = titulo;
            ResponsavelNome = responsavelNome;
            Status = status;
        }
    }
}
