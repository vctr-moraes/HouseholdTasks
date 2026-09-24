namespace HouseholdTasks.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateOnly DataCriacao { get; set; }
        public DateOnly DataConclusao { get; set; }
        public Status Status { get; set; }
        public string? Observacoes { get; set; }
        public Responsavel Responsavel { get; set; }
        public Importancia Importancia { get; set; }
    }
}
