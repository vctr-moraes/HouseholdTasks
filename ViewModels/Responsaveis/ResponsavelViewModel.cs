using HouseholdTasks.ViewModels.Tarefas;

namespace HouseholdTasks.ViewModels
{
    public class ResponsavelViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<VisualizarDetalhesTarefaViewModel> Tarefas { get; set; }
    }
}