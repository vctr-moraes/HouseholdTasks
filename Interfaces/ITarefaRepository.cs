using HouseholdTasks.Models;

namespace HouseholdTasks.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        public Task<List<Tarefa>> ObterTodas();
        public Task<Tarefa> ObterPorId(Guid id);
        public Task<List<Tarefa>> ObterPorStatus(Status status);
        public Task<List<Tarefa>> ObterPorResponsavel(Responsavel responsavel);
        public Task<List<Tarefa>> ObterPorImportancia(Importancia importancia);
        public void Adicionar(Tarefa tarefa);
        public void Atualizar(Tarefa tarefa);
        public void Remover(Tarefa tarefa);
    }
}
