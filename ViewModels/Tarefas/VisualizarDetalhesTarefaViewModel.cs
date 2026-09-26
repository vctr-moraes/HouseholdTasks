using System.ComponentModel.DataAnnotations;

namespace HouseholdTasks.ViewModels.Tarefas
{
    public class VisualizarDetalhesTarefaViewModel
    {
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Display(Name = "Data de Criação")]
        public DateOnly DataCriacao { get; set; }

        [Display(Name = "Data de Conclusão")]
        public DateOnly DataConclusao { get; set; }

        [Display(Name = "Status")]
        public StatusViewModel Status { get; set; }

        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        [Display(Name = "Responsável")]
        public ResponsavelViewModel Responsavel { get; set; }

        [Display(Name = "Importância")]
        public ImportanciaViewModel Importancia { get; set; }
    }
}
