namespace HouseholdTasks.Models
{
    public class Responsavel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}