using HouseholdTasks.Interfaces;
using HouseholdTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdTasks.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly HouseholdTasksDbContext _context;

        public TarefaRepository(HouseholdTasksDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> ObterTodas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> ObterPorId(Guid id)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Tarefa>> ObterPorStatus(Status status)
        {
            return await _context.Tarefas.Where(t => t.Status == status).ToListAsync();
        }

        public async Task<List<Tarefa>> ObterPorResponsavel(Responsavel responsavel)
        {
            return await _context.Tarefas.Where(t => t.Responsavel == responsavel).ToListAsync();
        }

        public async Task<List<Tarefa>> ObterPorImportancia(Importancia importancia)
        {
            return await _context.Tarefas.Where(t => t.Importancia == importancia).ToListAsync();
        }

        public void Adicionar(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Update(tarefa);
            _context.SaveChanges();
        }

        public void Remover(Tarefa tarefa)
        {
            _context.Remove(tarefa);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
