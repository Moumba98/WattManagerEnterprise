using WattManager.Domain.Entities;

namespace WattManager.Application.Repositories
{
    public interface IIngenieurRepository
    {
        Task<IEnumerable<Ingenieur>> GetAllWithCentralesAsync();
        Task<Ingenieur> AddAsync(Ingenieur ingenieur);
    }
}