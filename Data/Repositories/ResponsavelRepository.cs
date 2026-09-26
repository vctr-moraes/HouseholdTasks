using HouseholdTasks.Interfaces;
using HouseholdTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdTasks.Data.Repositories
{
    public class ResponsavelRepository : IResponsavelRepository
    {
        private readonly HouseholdTasksDbContext _context;

        public ResponsavelRepository(HouseholdTasksDbContext context)
        {
            _context = context;
        }

        public async Task<List<Responsavel>> ObterTodos()
        {
            return await _context.Responsaveis.ToListAsync();
        }

        public async Task<Responsavel> ObterPorId(Guid id)
        {
            return await _context.Responsaveis.FirstOrDefaultAsync(r => r.Id == id);
        }

        public void Adicionar(Responsavel responsavel)
        {
            _context.Add(responsavel);
            _context.SaveChanges();
        }

        public void Atualizar(Responsavel responsavel)
        {
            _context.Update(responsavel);
            _context.SaveChanges();
        }

        public void Remover(Responsavel responsavel)
        {
            _context.Remove(responsavel);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
