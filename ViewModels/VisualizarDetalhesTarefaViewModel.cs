namespace HouseholdTasks.ViewModels
{
    public class VisualizarDetalhesTarefaViewModel
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateOnly DataCriacao { get; set; }
        public DateOnly DataConclusao { get; set; }
        public StatusViewModel Status { get; set; }
        public string? Observacoes { get; set; }
        public ResponsavelViewModel Responsavel { get; set; }
        public ImportanciaViewModel Importancia { get; set; }
    }
}
