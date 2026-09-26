using System.ComponentModel.DataAnnotations;

namespace HouseholdTasks.ViewModels.Responsaveis
{
    public class VisualizarResponsaveisViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
