using System.ComponentModel.DataAnnotations;

namespace HouseholdTasks.ViewModels.Tarefas
{
    public class VisualizarTarefasViewModel
    {
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Status")]
        public StatusViewModel Status { get; set; }

        [Display(Name = "Responsável")]
        public ResponsavelViewModel Responsavel { get; set; }
    }
}
