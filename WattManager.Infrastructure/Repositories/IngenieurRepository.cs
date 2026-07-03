using Microsoft.EntityFrameworkCore;
using WattManager.Application.Repositories;
using WattManager.Domain.Entities;
using WattManager.Infrastructure.Persistence;

namespace WattManager.Infrastructure.Repositories
{
    public class IngenieurRepository : IIngenieurRepository
    {
        private readonly AppDbContext _context;

        // C'est le Repository qui hérite du DbContext maintenant !
        public IngenieurRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingenieur>> GetAllWithCentralesAsync()
        {
            return await _context.Ingenieurs.Include(i => i.Centrales).ToListAsync();
        }

        public async Task<Ingenieur> AddAsync(Ingenieur ingenieur)
        {
            _context.Ingenieurs.Add(ingenieur);
            await _context.SaveChangesAsync();
            return ingenieur;
        }
    }
}