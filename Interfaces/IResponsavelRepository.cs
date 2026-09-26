using HouseholdTasks.Models;

namespace HouseholdTasks.Interfaces
{
    public interface IResponsavelRepository : IRepository<Responsavel>
    {
        public Task<List<Responsavel>> ObterTodos();
        public Task<Responsavel> ObterPorId(Guid id);
        public void Adicionar(Responsavel responsavel);
        public void Atualizar(Responsavel responsavel);
        public void Remover(Responsavel responsavel);
    }
}
