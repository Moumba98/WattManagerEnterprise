using System.Collections.Generic;
using System.Threading.Tasks;
using WattManager.Application.Interfaces; 
using WattManager.Application.Repositories;
using WattManager.Domain.Entities;

namespace WattManager.Application.Services
{
    public class IngenieurService : IIngenieurService
    {
        private readonly IIngenieurRepository _ingenieurRepository;

        public IngenieurService(IIngenieurRepository ingenieurRepository)
        {
            _ingenieurRepository = ingenieurRepository;
        }

        public async Task<IEnumerable<Ingenieur>> GetAllWithCentralesAsync()
        {
            return await _ingenieurRepository.GetAllWithCentralesAsync();
        }

        public async Task<Ingenieur> CreateAsync(Ingenieur ingenieur)
        {
            return await _ingenieurRepository.AddAsync(ingenieur);
        }
    }
}